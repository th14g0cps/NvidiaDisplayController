using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using NLog;
using NvidiaDisplayController.Global.Controllers;
using NvidiaDisplayController.Interface.Monitors;
using NvidiaDisplayController.Objects.Entities;
using NvDisplay = NvAPIWrapper.Display.Display;
using WinDisplay = WindowsDisplayAPI.Display;

namespace NvidiaDisplayController.Global;

public class ProcessMonitorService : IDisposable
{
    private readonly DisplayController _displayController;
    private readonly ILogger _logger;
    private readonly CancellationTokenSource _cts = new();

    private Computer _computer = null!;
    private List<MonitorViewModel> _monitors = null!;
    private List<NvDisplay>? _nvidiaDisplays;

    private string? _activeRuleExe;

    public ProcessMonitorService(DisplayController displayController, ILogger logger)
    {
        _displayController = displayController;
        _logger = logger;
    }

    public void Start(Computer computer, List<MonitorViewModel> monitors, List<NvDisplay>? nvidiaDisplays)
    {
        _computer = computer;
        _monitors = monitors;
        _nvidiaDisplays = nvidiaDisplays;
        Task.Run(() => PollAsync(_cts.Token));
    }

    public void UpdateMonitors(List<MonitorViewModel> monitors, List<NvDisplay>? nvidiaDisplays)
    {
        _monitors = monitors;
        _nvidiaDisplays = nvidiaDisplays;
    }

    private async Task PollAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(2000, token);
                CheckProcesses();
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error in process monitor polling loop");
            }
        }
    }

    private void CheckProcesses()
    {
        var runningNames = Process.GetProcesses()
            .Select(p => p.ProcessName.ToLowerInvariant())
            .ToHashSet();

        ProcessRule? matchedRule = null;
        foreach (var rule in _computer.ProcessRules)
        {
            var exeWithoutExtension = Path.GetFileNameWithoutExtension(rule.ExecutableName).ToLowerInvariant();
            if (runningNames.Contains(exeWithoutExtension))
            {
                matchedRule = rule;
                break;
            }
        }

        if (matchedRule != null && matchedRule.ExecutableName != _activeRuleExe)
        {
            _activeRuleExe = matchedRule.ExecutableName;
            ApplyRule(matchedRule);
        }
        else if (matchedRule == null && _activeRuleExe != null)
        {
            _activeRuleExe = null;
            RestoreDefaults();
        }
    }

    private void ApplyRule(ProcessRule rule)
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            try
            {
                var monitorVm = _monitors.FirstOrDefault(m => m.Monitor.DisplayDevicePath == rule.MonitorDevicePath);
                if (monitorVm == null)
                {
                    _logger.Warn($"Process monitor: monitor not found for rule '{rule.ExecutableName}'");
                    return;
                }

                var profile = monitorVm.Monitor.Profiles.FirstOrDefault(p => p.Name == rule.ProfileName);
                if (profile == null)
                {
                    _logger.Warn($"Process monitor: profile '{rule.ProfileName}' not found");
                    return;
                }

                var nvidiaDisplay = _nvidiaDisplays?.FirstOrDefault(d => d.Name == monitorVm.ScreenName);
                _displayController.UpdateColorSettings(monitorVm.Display, profile.ProfileSetting, nvidiaDisplay);
                _logger.Info($"Process monitor: applied profile '{rule.ProfileName}' for process '{rule.ExecutableName}'");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to apply process rule");
            }
        });
    }

    private void RestoreDefaults()
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            try
            {
                foreach (var monitorVm in _monitors)
                {
                    var defaultProfile = monitorVm.Monitor.Profiles.FirstOrDefault(p => p.IsDefault);
                    if (defaultProfile == null) continue;

                    var nvidiaDisplay = _nvidiaDisplays?.FirstOrDefault(d => d.Name == monitorVm.ScreenName);
                    _displayController.UpdateColorSettings(monitorVm.Display, defaultProfile.ProfileSetting, nvidiaDisplay);
                }

                _logger.Info("Process monitor: restored default profiles");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to restore default profiles");
            }
        });
    }

    public void Dispose()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}

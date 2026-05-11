using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NvidiaDisplayController.Objects.Entities;

namespace NvidiaDisplayController.Interface.ProcessRules;

public class ProcessRuleViewModel : INotifyPropertyChanged
{
    public ProcessRule Rule { get; }
    public Action<ProcessRuleViewModel> RemoveRequested { get; set; } = null!;

    public ProcessRuleViewModel(ProcessRule rule)
    {
        Rule = rule;
    }

    public string ExecutableName => Rule.ExecutableName;
    public string MonitorName => Rule.MonitorName;
    public string ProfileName => Rule.ProfileName;

    public void Remove()
    {
        RemoveRequested?.Invoke(this);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

using System.Diagnostics;
using System.Windows.Forms;

namespace NvidiaDisplayController.Global.Controllers;

public class RegistryController
{
    private static string TaskName => "NvidiaDisplayController";

    public void RegisterForStartWithWindows(bool isStartWithWindows)
    {
        if (isStartWithWindows)
            CreateStartupTask();
        else
            DeleteStartupTask();
    }

    private static void CreateStartupTask()
    {
        var exePath = Application.ExecutablePath;

        // Delete any existing task first to avoid duplicates
        RunSchtasks($"/delete /tn \"{TaskName}\" /f");

        RunSchtasks(
            $"/create /tn \"{TaskName}\" /tr \"\\\"{exePath}\\\"\" /sc ONLOGON /rl HIGHEST /f");
    }

    private static void DeleteStartupTask()
    {
        RunSchtasks($"/delete /tn \"{TaskName}\" /f");
    }

    private static void RunSchtasks(string arguments)
    {
        using var process = new Process();
        process.StartInfo = new ProcessStartInfo
        {
            FileName = "schtasks.exe",
            Arguments = arguments,
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        process.Start();
        process.WaitForExit();
    }
}
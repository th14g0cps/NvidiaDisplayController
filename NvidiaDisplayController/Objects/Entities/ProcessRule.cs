namespace NvidiaDisplayController.Objects.Entities;

public class ProcessRule
{
    public ProcessRule(string executableName, string monitorDevicePath, string monitorName, string profileName)
    {
        ExecutableName = executableName;
        MonitorDevicePath = monitorDevicePath;
        MonitorName = monitorName;
        ProfileName = profileName;
    }

    public string ExecutableName { get; set; }
    public string MonitorDevicePath { get; set; }
    public string MonitorName { get; set; }
    public string ProfileName { get; set; }
}

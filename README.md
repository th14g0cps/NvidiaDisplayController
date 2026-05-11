
# NVIDIA Display Controller

This is only for NVIDIA GPU's. Allows you to change display settings and easily switch between different profiles without having to manually adjust settings each time. Applies to the monitor and not a specific program.

> **Fork maintained by [@th14g0cps](https://github.com/th14g0cps)** with the following improvements over the original project.

## Changelog

### Migration to .NET 10
- Target framework updated from `net7.0-windows` to `net10.0-windows` across all projects in the solution.
- Removed hardcoded references to .NET 7 DLLs and paths.
- Removed `System.Drawing.Common` package (built into the Windows Desktop .NET 10+ runtime).

### Process Rules — Automatic Profile Switching
New feature that monitors running processes and automatically applies color profiles:

- Create rules linking an executable (e.g. `cs2.exe`) to a specific monitor and profile.
- When the process is detected as running, the profile is applied automatically.
- When the process exits, all monitors revert to the **Default** profile.
- Rules are persisted in `Data\Data.json` alongside all other application data.
- Monitoring runs in the background with a 2-second polling interval, with negligible performance impact.

**How to use:**
1. In the main window, find the **Process Rules** section at the bottom.
2. Enter the executable name (with or without `.exe`), select the target monitor and profile.
3. Click **Add**.
4. To remove a rule, click **Remove** on the corresponding row in the list.




## Features

- Adjust the brightness, contrast, gamma, and digital vibrance settings to your preference.
- Automatically detects all displays connected to the computer and creates a base default profile for each.
- Configure settings for up to five profiles for each monitor to easily switch between different configurations.
- Set a profile as the default so no need to select each time. Optionally, set the default profiles to apply to all monitors on start across all displays.
- Minimizes to system tray to avoid clutter on taskbar. Right click icon to open/close application once minimized.
- View selected profiles when hoving mouse over icon in taskbar.
- Extremely lightweight with low resource use (under 100 MB)


## Requirements

- NVIDIA GPU (with installed drivers)
- Windows (tested with 10/11)


## How to Use

Run the executable and select a monitor from the collection at the top. To create a profile hit the green plus symbol in the Profile section. From there you name the Profile and proceed to set the settings in the Detail section. 

Settings will not be applied until the 'Apply' button is pressed at the bottom. To update the settings of a profile WITHOUT applying them to the monitor click the 'Update' button. To revert changes made before applying hit the 'Revert' button.

All the data is stored where the executable resides (\InstallLocation\Data\Data.json). If you need to reset the data, there is a help button at the top where you can do that.



## Screenshot

![App Screenshot](https://github.com/user-attachments/assets/cf9804e3-7d16-45f7-9b28-d85b0477ddde)



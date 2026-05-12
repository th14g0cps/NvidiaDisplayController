
# NVIDIA Display Controller

This is only for NVIDIA GPU's. Allows you to change display settings and easily switch between different profiles without having to manually adjust settings each time. Applies to the monitor and not a specific program.

> **Fork maintained by [@th14g0cps](https://github.com/th14g0cps)** with the following improvements over the original project.

---

## Changelog

### v2.0.0

#### Migration to .NET 10
- Target framework updated from `net7.0-windows` to `net10.0-windows` across all projects in the solution.
- Removed hardcoded references to .NET 7 DLLs and paths.
- Removed `System.Drawing.Common` package (built into the Windows Desktop .NET 10+ runtime).

#### Process Rules — Automatic Profile Switching
New feature that monitors running processes and automatically applies color profiles:

- Create rules linking an executable (e.g. `cs2.exe`) to a specific monitor and profile.
- When the process is detected as running, the profile is applied automatically.
- When the process exits, all monitors revert to the **Default** profile.
- Rules are persisted in `Data\Data.json` alongside all other application data.
- Monitoring runs in the background with a 2-second polling interval, with negligible performance impact.

#### Browse Executable
- Instead of typing the executable name manually, a **Browse...** button opens a file picker filtered to `.exe` files.

#### Start with Windows
- A **Start with Windows** checkbox registers or unregisters the application in the Windows startup registry key (`HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Run`).

#### UI Improvements
- Main window is now resizable with a minimum width of 750px — dropdowns no longer break on smaller layouts.
- **Buy Me a Coffee** button added to the top-right toolbar, linking to [buymeacoffee.com/th14g0](https://buymeacoffee.com/th14g0).
- UAC manifest embedded — the app automatically requests administrator elevation on launch (required by Windows to apply display color settings).

---

## Features

- Adjust brightness, contrast, gamma, and digital vibrance per monitor.
- Automatically detects all displays connected to the GPU and creates a default profile for each.
- Up to five profiles per monitor for quick switching between configurations.
- Apply a profile as active — optionally auto-apply on Windows startup.
- **Process Rules:** automatically switch profiles when specific applications are running.
- **Start with Windows** option built into the UI.
- Minimizes to the system tray. Right-click the tray icon to show or exit.
- Hover over the tray icon to see the active profile for each monitor.
- Hotkey support: assign a keyboard shortcut to any profile for instant switching.

---

## Requirements

- NVIDIA GPU with installed drivers
- Windows 10 or 11
- [.NET 10 Desktop Runtime (x64)](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) — required to run the application

---

## How to Use

### First run
1. Run `NvidiaDisplayController.exe` as Administrator (a UAC prompt will appear automatically).
2. The app detects all monitors connected to your GPU and creates a **Default** profile for each.

### Managing profiles
1. Select a monitor from the **Monitors** section.
2. Click the **+** button in the **Profiles** section to create a new profile and give it a name.
3. Adjust **Brightness**, **Contrast**, **Gamma**, and **Digital Vibrance** in the **Profile Details** section.
4. Click **Apply** to apply the settings to the monitor immediately.
5. Click **Update** to save changes to the profile without applying them.
6. Click **Revert** to discard unsaved changes.

### Process Rules (automatic switching)
1. Scroll to the **Process Rules** section at the bottom of the window.
2. Click **Browse...** and select the target `.exe` file.
3. Choose the **Monitor** and **Profile** to activate when that process runs.
4. Click **Add**.
5. When the process starts, the profile switches automatically. When it exits, all monitors revert to their **Default** profile.
6. To delete a rule, click **Remove** on the corresponding row.

### Startup options
- **Apply Settings on Start** — re-applies the active profile for all monitors every time the app launches.
- **Start with Windows** — registers the app in Windows startup so it launches automatically on login.

### Hotkeys
- Select a profile and assign a key combination (Ctrl / Alt / Shift + key) in the **Profile Details** section.
- Click **Update** to save. The hotkey will activate that profile globally even when the app is minimized.

### Reset
- Click the **?** (About) button in the top-right corner and use the **Reset** button to wipe all data and start fresh.

---

## Screenshot

![App Screenshot](https://github.com/user-attachments/assets/71877578-5fa4-4d74-959f-7d746a5330db)

---

## Support

If you find this useful, consider buying me a coffee ☕

[![Buy Me a Coffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://buymeacoffee.com/th14g0)

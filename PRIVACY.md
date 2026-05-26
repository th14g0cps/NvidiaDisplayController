Privacy Policy for NvidiaDisplayController
Last Updated: May 26, 2026

This Privacy Policy describes how NvidiaDisplayController ("the Application") handles information when you use the software.

We are committed to protecting user privacy. The Application is a local utility designed to manage display color profiles, brightness, contrast, gamma, and digital vibrance for NVIDIA GPUs on Windows operating systems.

1. Information Collection and Use
No Personal Data Collection: The Application does not collect, harvest, store, or transmit any personally identifiable information (PII), personal data, or usage telemetria.

Local Data Storage: All configuration settings, custom user profiles, and application mapping rules (Process Rules) are stored strictly locally on your device in a structured local file (Data\Data.json). No configuration data is ever uploaded to a remote server or third-party service.

Process Monitoring: The "Process Rules" feature scans active process names locally on your machine at a defined interval solely to determine when to trigger automatic display profile switching. This data never leaves your device and is not logged or tracked.

2. Permissions and System Access
Administrator Privileges (UAC): The Application requests elevated administrative access on launch. This permission is required exclusively to interface with official Windows and NVIDIA APIs to modify system display hardware configurations (such as Gamma ramps and color controls).

Windows Task Scheduler / Startup: The "Start with Windows" feature creates a local startup task or registry entry (schtasks.exe) to automate launching the program on user login. This mechanism is entirely local and managed by your operating system.

3. Third-Party Services
Links to External Platforms: The Application contains a link to an external tipping platform ("Buy Me a Coffee"). Clicking this option opens your default web browser to a third-party website. We do not control, store, or have access to any payment information or data handled by external financial platforms.

4. Changes to This Privacy Policy
We may update our Privacy Policy from time to time to reflect application changes or legislative updates. Any changes will be posted directly within the open-source repository documentation.

5. Contact Us
If you have any questions regarding this Privacy Policy or the local behavior of the Application, you can open an issue or contact the project maintainer directly on the official GitHub repository:
https://github.com/th14g0cps/NvidiaDisplayController

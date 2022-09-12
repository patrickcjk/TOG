using Microsoft.Win32;

namespace TOG.Common;

public static class Tools
{
    public static string GetInstallationPath(string applicationName)
    {
        using var key = Registry.LocalMachine.OpenSubKey(@$"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\{applicationName}");

        if (key == null)
            throw new Exception("install registry key not found");

        var directory = (string?)key!.GetValue("InstallLocation");

        if (string.IsNullOrEmpty(directory))
            throw new Exception("Empty install location");

        if (!Directory.Exists(directory))
            throw new Exception("install path not found");

        return directory;
    }
}

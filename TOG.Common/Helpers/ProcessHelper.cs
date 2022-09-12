using PInvoke;
using TOG.Common.Exceptions;

namespace TOG.Common.Helpers;

public static class ProcessHelper
{
    public static Kernel32.PROCESS_INFORMATION CreateProcess(string path)
    {
        var lpStartupInfo = new Kernel32.STARTUPINFO();

        if (!Kernel32.CreateProcess(
            path,
            null,
            IntPtr.Zero,
            IntPtr.Zero,
            false,
            Kernel32.CreateProcessFlags.NORMAL_PRIORITY_CLASS,
            IntPtr.Zero,
            null,
            ref lpStartupInfo,
            out var pi)
        )
            throw new LastWin32Exception("CreateProcess");

        return pi;
    }

    public static Kernel32.SafeObjectHandle OpenProcess(int processId)
    {
        return Kernel32.OpenProcess(Kernel32.ACCESS_MASK.GenericRight.GENERIC_ALL, false, processId);
    }
}

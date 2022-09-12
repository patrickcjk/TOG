namespace TOG.Common.Exceptions;

public class LastWin32Exception : Exception
{
    public LastWin32Exception(string methodName) : base($"calling {methodName}: {Marshal.GetLastWin32Error()}")
    {
    }
}

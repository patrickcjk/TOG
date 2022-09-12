namespace TOG.Common.Helpers;

public enum LogType
{
    None,
    Error,
    Info,
    Warning,
    Success
}

/// <summary>
/// TODO: Use Serilog
/// </summary>
public class Logger
{
    private string GetDateTimeFormatted()
        => DateTime.Now.ToString("g");

    private static List<LogInfo> logInfoList = new List<LogInfo>()
    {
        new LogInfo(LogType.Error, ConsoleColor.Red, "Error  "),
        new LogInfo(LogType.Info, ConsoleColor.Blue, "Info   "),
        new LogInfo(LogType.Warning, ConsoleColor.Yellow, "Warn   "),
        new LogInfo(LogType.Success, ConsoleColor.Green, "Success")
    };

    public void Log(LogType logType, string message)
    {
        var logInfo = logInfoList.Where(x => x.Type.Equals(logType)).First();

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"[{GetDateTimeFormatted()}] [");

        Console.ForegroundColor = logInfo.Color;
        Console.Write(logInfo.Prefix);

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"] {message}");
    }

    private class LogInfo
    {
        public LogType Type { get; set; }

        public ConsoleColor Color { get; set; }

        public string Prefix { get; set; }

        public LogInfo(LogType type, ConsoleColor color, string prefix)
        {
            Type = type;
            Color = color;
            Prefix = prefix;
        }
    }

}

using System.Text;
using TOG.Common.Helpers;

namespace TOG.Common.Templates;

public class BaseTemplate
{
    protected const char Space = '	';
    protected readonly StringBuilder _sb = new();
    protected static readonly Logger _logger = new Logger();

    public BaseTemplate() { }

    public void AddInstruction(string instruction, int intend = 2)
        => _sb.AppendLine($"{new string(Space, intend)}{instruction}");

    public void AddHeader(string? gameVersion)
    {
        AddInstruction("/*", 0);
        AddInstruction($"Generated using Deathstroke's TGO (https://github.com/patrickcjk/tgo)", 1);
        AddInstruction($"At {DateTime.Now}", 1);
        AddInstruction(string.IsNullOrEmpty(gameVersion) ? "Unknown game version" : $"Game version {gameVersion}", 1);
        AddInstruction("*/", 0);
    }

    public void Build(string path)
        => File.WriteAllText(path, Build());

    public string Build()
        => _sb.ToString();

    public void SkipLine()
        => _sb.AppendLine();
}

using TOG.Common.Templates;
using TOG.Common.Helpers;
using TOG.App.Definitions;

namespace TOG.App.Templates;

public class CppTemplate : BaseTemplate
{
    private static Dictionary<string, int> typeSizeMap = new () 
    {
        { "Boolean", 1 }, // Real size 1 but padded 4
        { "Single", 4 }, // Float
        //{ "EFT.HealthSystem.ValueStruct", 0xF }, // ???
        { "UnityEngine.RaycastHit", 3 * sizeof(float) }, // Vector 3
        { "UnityEngine.Vector2", 2 * sizeof(float) }, // Vector 2
        { "Int32", 4 }
    };

    private void GenerateOffset(OffsetDefinition offsetDefinition, int indent)
    {
        string comment = $"{offsetDefinition.FoundField.OffsetHex} {offsetDefinition.FoundField.Name} : {offsetDefinition.FoundField.FieldType}";
        AddInstruction($"constexpr auto {offsetDefinition.OffsetName} = 0x{offsetDefinition.FoundField.Offset:X}; // {comment}", indent);
    }

    private void GenerateSizes(NamespaceDefinition namespaceDefinition, int indent)
    {
        AddInstruction($"constexpr auto size = 0x{namespaceDefinition.FoundType.InnerDefinition.InstanceSize:X};", indent);

        // Find the last offset in the list
        var lastOffset = namespaceDefinition.OffsetDefinitions.OrderByDescending(c => c.FoundField.Offset).First();

        var lastOffsetValue = lastOffset.FoundField.Offset;

        // Find the last offset size
        var lastOffsetSize = 0x8;
        if (typeSizeMap.TryGetValue(lastOffset.FoundField.FieldType, out var size))
            lastOffsetSize = size;

        // Calculate the "max use size"
        var safeSize = lastOffsetValue + lastOffsetSize;

        // Create the comment
        string comment = $"0x{lastOffsetValue:X} + sizeof({lastOffset.FoundField.FieldType}) = 0x{lastOffsetValue:X} + 0x{lastOffsetSize:X}";

        // Prind
        AddInstruction($"constexpr auto max_use_size = 0x{safeSize:X}; // {comment}", indent);
        SkipLine();
    }

    private void GenerateNamespace(NamespaceDefinition namespaceDefinition, int indent, bool isLast = false)
    {
        _logger.Log(LogType.Info, $"Generating namespace {namespaceDefinition.DumpNamespaceName}");

        AddInstruction($"// [{namespaceDefinition.FoundType.ClassType}] {namespaceDefinition.FoundType.FullName}", indent);
        AddInstruction($"namespace {namespaceDefinition.DumpNamespaceName}", indent);
        AddInstruction("{", indent);

        // Size
        GenerateSizes(namespaceDefinition, indent + 1);

        // Generate offsets
        foreach (var offsetDefinition in namespaceDefinition.OffsetDefinitions)
            GenerateOffset(offsetDefinition, indent + 1);

        // Generate child namespaces (if so)
        if (namespaceDefinition.NamespaceDefinitions.Count > 0)
        {
            SkipLine();

            foreach (var _namespaceDefinition in namespaceDefinition.NamespaceDefinitions)
                GenerateNamespace(_namespaceDefinition, indent + 1, _namespaceDefinition == namespaceDefinition.NamespaceDefinitions.Last());
        }

        AddInstruction("}", indent);

        if (!isLast)
            SkipLine();
    }

    public void HandleNamespace(NamespaceDefinition namespaceDefinition, int indent, bool isLast)
    {
        GenerateNamespace(namespaceDefinition, indent, isLast);
    }
}

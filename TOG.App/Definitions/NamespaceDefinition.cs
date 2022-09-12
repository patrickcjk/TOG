using Unispect;

namespace TOG.App.Definitions;

public class NamespaceDefinition
{
    public string DumpNamespaceName { get; set; }

    public string? NamespaceName { get; set; }

    public string? ClassName { get; set; }

    public string? PreviousFoundField { get; set; }

    public List<OffsetDefinition> OffsetDefinitions { get; set; } = new();

    public List<NamespaceDefinition> NamespaceDefinitions { get; set; } = new();

    public TypeDefWrapper FoundType { get; set; }

    public NamespaceDefinition(string dumpNamespaceName)
    {
        DumpNamespaceName = dumpNamespaceName;
    }

    public NamespaceDefinition(string dumpNamespaceName, List<OffsetDefinition> offsetDefinitions) : this(dumpNamespaceName)
    {
        OffsetDefinitions = offsetDefinitions;
    }

    public NamespaceDefinition(string dumpNamespaceName, List<OffsetDefinition> offsetDefinitions, List<NamespaceDefinition> namespaceDefinitions)
        : this(dumpNamespaceName, offsetDefinitions)
    {
        NamespaceDefinitions = namespaceDefinitions;
    }

    public NamespaceDefinition WithNamespace(string namespaceName)
    {
        NamespaceName = namespaceName;
        return this;
    }

    public NamespaceDefinition WithClass(string className)
    {
        ClassName = className;
        return this;
    }

    public NamespaceDefinition FromPreviousFoundField(string previousFoundField)
    {
        PreviousFoundField = previousFoundField;
        return this;
    }
}

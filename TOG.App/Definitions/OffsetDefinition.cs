using Unispect;

namespace TOG.App.Definitions;

public class OffsetDefinition
{
    public string OffsetName { get; set; }

    public string? TypeName { get; set; }

    public string? FieldName { get; set; }

    public bool IsUnknownType { get; set; } = false;

    public bool IsUnknownFieldName { get; set; } = false;

    public string? ParentType { get; set; }

    public Func<List<FieldDefWrapper>, FieldDefWrapper?> FieldFilterExpression { get; private set; }

    //public FieldInfo FoundField { get; set; }

    public FieldDefWrapper FoundField { get; set; }

    public OffsetDefinition(string offsetName)
    {
        OffsetName = offsetName;
    }

    public OffsetDefinition WithFieldName(string fieldName)
    {
        FieldName = fieldName;
        return this;
    }

    public OffsetDefinition WithType(string typeName)
    {
        TypeName = typeName;
        return this;
    }

    public OffsetDefinition WithFieldFilter(Func<List<FieldDefWrapper>, FieldDefWrapper?> expression)
    {
        FieldFilterExpression = expression;
        return this;
    }

    public OffsetDefinition WithUnknownFieldName()
    {
        IsUnknownFieldName = true;
        return this;
    }

    public OffsetDefinition WithUnknownType()
    {
        IsUnknownType = true;
        return this;
    }

    public OffsetDefinition FromParentType(string parentType)
    {
        ParentType = parentType;
        return this;
    }
}

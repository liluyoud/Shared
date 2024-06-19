using System.ComponentModel;

namespace Dclt.Directus;

public class Operation
{
    public const string And = "_and";
    public const string Or = "_or";
    public const string Equal = "_eq";
    public const string NotEqual = "_neq";
    public const string GreaterThan = "_gt";
    public const string GreaterThanOrEqual = "_gte";
    public const string LessThan = "_lt";
    public const string LessThanOrEqual = "_lte";
    public const string In = "_in";
    public const string NotIn = "_nin";
    public const string Between = "_between";
    public const string NotBetween = "_nbetween";
    public const string IsNull = "_null";
    public const string IsNotNull = "_nnull";
    public const string Contains = "_icontains";
    public const string NotContains = "_ncontains";
}

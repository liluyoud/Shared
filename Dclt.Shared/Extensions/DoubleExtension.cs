namespace Dclt.Shared.Extensions;

public static class DoubleExtension
{
    public static double Absolute(this double value)
    {
        return Math.Abs(value);
    }

    public static double? Absolute(this double? value)
    {
        return value != null ? Math.Abs(value.Value) : null;
    }
}

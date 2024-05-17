using System.ComponentModel;
using System.Reflection;

namespace Dclt.Shared.Extensions;

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        Type type = value.GetType();
        MemberInfo[] memberInfo = type.GetMember(value.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                return ((DescriptionAttribute)attrs[0]).Description;
            }
        }
        return value.ToString();
    }

    public static int GetValue(this Enum value)
    {
        return Convert.ToInt32(value);
    }


}

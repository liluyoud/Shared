using Dclt.Shared.Extensions;
using Dclt.Shared.Models;

namespace Dclt.Shared.Helpers;

public static class EnumHelper
{
    public static List<EnumItem> GetList<TEnum>() where TEnum : Enum
    {
        return Enum.GetValues(typeof(TEnum))
                   .Cast<TEnum>()
                   .Select(e => new EnumItem(Id: e.GetValue(), Text: e.GetDescription()))
                   .ToList();
    }
}

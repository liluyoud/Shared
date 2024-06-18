using Dclt.Shared.Models;

namespace Dclt.Shared.Extensions;

public static class MapExtension
{
    public static string? GetKey(this List<KeyValue>? list, string? key)
    {
        if (list != null && !string.IsNullOrEmpty(key))
        {
            var item = list.FirstOrDefault(s => s.Key.ToLower() == key.ToLower());
            if (item != null)
            {
                return item.Value;
            }
        }
        return null;
    }
}

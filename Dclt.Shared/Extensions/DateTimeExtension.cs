using Dclt.Shared.Enums;

namespace Dclt.Shared.Extensions;

public static class DateTimeExtension
{
    public static DayNight IsDayOrNight(this DateTime currentTime, DateTime sunrise, DateTime sunset)
    {
        if (currentTime >= sunrise && currentTime < sunset)
        {
            return DayNight.Day;
        }
        else
        {
            return DayNight.Night;
        }
    }
}

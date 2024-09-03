using Dclt.Evolution.Enums;
using System.ComponentModel;
using System.Reflection;

namespace Dclt.Evolution.Extensions;

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo? field = value.GetType().GetField(value.ToString());
        if (field != null)
        {
            DescriptionAttribute? attribute = field.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute != null) return attribute.Description;
        }
        return value.ToString();
    }

    public static int GetValue(this Enum value)
    {
        return Convert.ToInt32(value);
    }

    public static MediaType GetMediaType(this MimeType value)
    {
        switch (value)
        {
            case MimeType.ImageJpg:
            case MimeType.ImagePng:
            case MimeType.ImageGif:
            case MimeType.ImageBmp:
            case MimeType.ImageWebp:
            case MimeType.ImageSvg:
            case MimeType.ImageTiff:
                return MediaType.Image;

            case MimeType.AudioMp3:
            case MimeType.AudioWav:
            case MimeType.AudioOgg:
            case MimeType.AudioWebM:
            case MimeType.AudioAcc:
            case MimeType.AudioFlac:
                return MediaType.Audio;

            case MimeType.VideoMp4:
            case MimeType.VideoWebM:
            case MimeType.VideoOgg:
            case MimeType.VideoMpg:
            case MimeType.VideoAvi:
                return MediaType.Video;

            default:
                return MediaType.Document;
        }
    }
}

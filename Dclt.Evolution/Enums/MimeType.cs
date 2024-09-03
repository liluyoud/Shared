using System.ComponentModel;

namespace Dclt.Evolution.Enums;

public enum MimeType
{
    [Description("image/jpeg")]
    ImageJpg,
    [Description("image/png")]
    ImagePng,
    [Description("image/gif")]
    ImageGif,
    [Description("image/bmp")]
    ImageBmp,
    [Description("image/webp")]
    ImageWebp,
    [Description("image/svg+xml")]
    ImageSvg,
    [Description("image/tiff")]
    ImageTiff,

    [Description("audio/mpeg")]
    AudioMp3,
    [Description("audio/wav")]
    AudioWav,
    [Description("audio/ogg")]
    AudioOgg,
    [Description("audio/webm")]
    AudioWebM,
    [Description("audio/aac")]
    AudioAcc,
    [Description("audio/flac")]
    AudioFlac,

    [Description("video/mp4")]
    VideoMp4,
    [Description("video/webm")]
    VideoWebM,
    [Description("video/ogg")]
    VideoOgg,
    [Description("video/mpeg")]
    VideoMpg,
    [Description("video/x-msvideo")]
    VideoAvi,

    [Description("application/json")]
    AppJson,
    [Description("application/xml")]
    AppXml,
    [Description("application/javascript")]
    AppJs,
    [Description("application/pdf")]
    AppPdf,
    [Description("application/zip")]
    AppZip,
    [Description("application/gzip")]
    AppGZip,
    [Description("application/octet-stream")]
    AppBin,
    [Description("application/msword")]
    AppWord,
    [Description("application/vnd.ms-excel")]
    AppExcel,
    [Description("application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
    AppWordXml,
    [Description("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
    AppExcelXml,

    [Description("text/plain")]
    Text,
    [Description("text/html")]
    TextHtml,
    [Description("text/css")]
    TextCss,
    [Description("text/javascript")]
    TextJs,
    [Description("text/xml")]
    TextXml,
    [Description("text/csv")]
    TextCsv
}

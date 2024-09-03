using System.Text.Json.Serialization;

namespace Dclt.Evolution.Models;

public class ImageMessage
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("mimetype")]
    public string? Mimetype { get; set; }

    [JsonPropertyName("caption")]
    public string? Caption { get; set; }

    [JsonPropertyName("fileSha256")]
    public string? FileSha256 { get; set; }

    [JsonPropertyName("fileLength")]
    public string? FileLength { get; set; }

    [JsonPropertyName("height")]
    public int? Height { get; set; }

    [JsonPropertyName("width")]
    public int? Width { get; set; }

    [JsonPropertyName("mediaKey")]
    public string? MediaKey { get; set; }

    [JsonPropertyName("fileEncSha256")]
    public string? FileEncSha256 { get; set; }

    [JsonPropertyName("directPath")]
    public string? DirectPath { get; set; }

    [JsonPropertyName("mediaKeyTimestamp")]
    public string? MediaKeyTimestamp { get; set; }

    [JsonPropertyName("jpegThumbnail")]
    public string? JpegThumbnail { get; set; }
}
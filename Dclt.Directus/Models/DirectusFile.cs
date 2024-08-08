using System.Text.Json.Serialization;

namespace Dclt.Directus.Models;

public class DirectusFile
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("storage")]
    public string? Storage { get; set; }

    [JsonPropertyName("filename_disk")]
    public string? FilenameDisk { get; set; }

    [JsonPropertyName("filename_download")]
    public string? FilenameDownload { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("folder")]
    public Guid? Folder { get; set; }

    [JsonPropertyName("uploaded_by")]
    public Guid? UploadedBy { get; set; }

    [JsonPropertyName("uploaded_on")]
    public DateTime? UploadedOn { get; set; }

    [JsonPropertyName("modified_by")]
    public Guid? ModifiedBy { get; set; }

    [JsonPropertyName("modified_on")]
    public DateTime? ModifiedOn { get; set; }

    [JsonPropertyName("charset")]
    public string? Charset { get; set; }

    [JsonPropertyName("filesize")]
    public long? FileSize { get; set; }

    [JsonPropertyName("width")]
    public int? Width { get; set; }

    [JsonPropertyName("height")]
    public int? Height { get; set; }

    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    [JsonPropertyName("embed")]
    public string? Embed { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("tags")]
    public string[]? Tags { get; set; }

    [JsonPropertyName("metada")]
    public string? MetaData { get; set; }

    [JsonPropertyName("focal_point_x")]
    public int? FocalPointX { get; set; }

    [JsonPropertyName("focal_point_y")]
    public int? FocalPointYX { get; set; }

    [JsonPropertyName("tus_id")]
    public string? TusId { get; set; }

    [JsonPropertyName("tus_data")]
    public string? TusData { get; set; }
}

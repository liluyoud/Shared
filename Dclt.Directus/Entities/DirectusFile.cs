using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dclt.Directus.Entities;

[Table("directus_files")]
public class DirectusFile
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("storage")]
    public string? Storage { get; set; }

    [Column("filename_disk")]
    public string? FilenameDisk { get; set; }

    [Column("filename_download")]
    public string? FilenameDownload { get; set; }

    [Column("title")]
    public string? Title { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("folder")]
    public Guid? Folder { get; set; }

    [Column("uploaded_by")]
    public Guid? UploadedBy { get; set; }

    [Column("uploaded_on")]
    public DateTime? UploadedOn { get; set; }

    [Column("modified_by")]
    public Guid? ModifiedBy { get; set; }

    [Column("modified_on")]
    public DateTime? ModifiedOn { get; set; }

    [Column("charset")]
    public string? Charset { get; set; }

    [Column("filesize")]
    public long? FileSize { get; set; }

    [Column("width")]
    public int? Width { get; set; }

    [Column("height")]
    public int? Height { get; set; }

    [Column("duration")]
    public int? Duration { get; set; }

    [Column("embed")]
    public string? Embed { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("location")]
    public string? Location { get; set; }

    [Column("tags")]
    public string[]? Tags { get; set; }

    [Column("metada")]
    public string? MetaData { get; set; }

    [Column("focal_point_x")]
    public int? FocalPointX { get; set; }

    [Column("focal_point_y")]
    public int? FocalPointYX { get; set; }

    [Column("tus_id")]
    public string? TusId { get; set; }

    [Column("tus_data")]
    public string? TusData { get; set; }
}

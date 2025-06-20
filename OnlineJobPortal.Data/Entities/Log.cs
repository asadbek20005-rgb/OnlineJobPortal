using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Entities;

[Table("logs", Schema = "application")]
public class Log
{
    [Column("id")]
    [Key]
    public int Id { get; set; }
    [Column("level")]
    [Required]
    public string Level { get; set; } = string.Empty;
    [Column("message")]
    [Required]
    public string Message { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    [Column("path")]
    [Required]
    public string Path { get; set; } = string.Empty;
    [Column("method")]
    [Required]
    public string Method { get; set; } = string.Empty;
    [Column("status_code")]
    [Required]
    public int StatusCode { get; set; }
}
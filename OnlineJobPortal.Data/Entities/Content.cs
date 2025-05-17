using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Entities;
[Table("contents", Schema ="application")]
public class Content
{
    [Column("id")]
    [Key]
    public int Id { get; set; }

    [Column("file_name")]
    [StringLength(50)]
    [Required]
    public string FileName { get; set; }


    [Column("content_type")]
    [Required]
    public string ContentType { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }



}

using OnlineJobPortal.Data.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Entities;
[Table("companies", Schema = "application")]
public class Company : Date
{
    [Column("id")]
    [Key]
    public int Id { get; set; }


    [Column("name")]
    [StringLength(255)]
    [Required]
    public string Name { get; set; } = string.Empty;


    [Column("about")]
    [DataType(DataType.MultilineText)]
    [Required]
    public string About { get; set; } = string.Empty;

    [Column("city_id")]
    [Required]
    public int CityId { get; set; }

    [ForeignKey(nameof(CityId))]
    public City? City { get; set; } = null!;
}

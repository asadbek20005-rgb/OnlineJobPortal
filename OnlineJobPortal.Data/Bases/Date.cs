using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineJobPortal.Data.Bases;

public class Date
{
    [Column("created_date")]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    [Column("updated_date")]
    public DateTime? UpdatedDate { get; set; } 

}

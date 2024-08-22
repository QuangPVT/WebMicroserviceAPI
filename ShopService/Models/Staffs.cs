using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopService.Models
{
    [Table("Staffs")]
    public class Staffs
    {
        [Key]
        [Column("staff_id")]
        [MaxLength(30)]
        public string StaffId { get; set; }

        [Required]
        [Column("user_id")]
        [MaxLength(10)]
        public string UserId { get; set; }

        [Required]
        [Column("shop_id")]
        [MaxLength(20)]
        public string ShopId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopService.Models
{
    [Table("Shop_Info")]
    public class ShopInfo
    {
        [Key]
        [Column("shop_id")]
        [MaxLength(20)]
        public string ShopId { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("address")]
        [MaxLength(150)]
        public string Address { get; set; }

        [Required]
        [Column("phone_support")]
        [MaxLength(12)]
        public string PhoneSupport { get; set; }
    }
}

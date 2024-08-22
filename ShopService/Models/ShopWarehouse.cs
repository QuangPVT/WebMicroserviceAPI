using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopService.Models
{
    [Table("Shop_Warehouse")]
    public class ShopWarehouse
    {
        [Key]
        [Column("shop_id")]
        [MaxLength(20)]
        public string ShopId { get; set; }

        [Required]
        [Column("product_id")]
        [MaxLength(10)]
        public string ProductId { get; set; }

        [Required]
        [Column("stock_quantity")]
        public int StockQuantity { get; set; }

        [Required]
        [Column("on_order")]
        public int OnOrder { get; set; }
    }
}

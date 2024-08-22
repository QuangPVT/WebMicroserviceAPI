using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogService.Models
{
    [Table("Blog_Type")]
    public class BlogType
    {
        [Key]
        [Column("type_id")]
        [MaxLength(20)]
        public string TypeId { get; set; }

        [Required]
        [Column("description")]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}

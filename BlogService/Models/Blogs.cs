using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogService.Models
{
    [Table("Blogs")]
    public class Blogs
    {
        [Key]
        [Column("blog_id")]
        [MaxLength(10)]
        public string BlogId { get; set; }

        [Required]
        [Column("user_id")]
        [MaxLength(10)]
        public string UserId { get; set; }

        [Required]
        [Column("title")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [Column("picture")]
        public string Picture { get; set; }

        [Required]
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Required]
        [Column("last_modify")]
        public DateTime LastModify { get; set; }

        [Required]
        [Column("status")]
        public bool Status { get; set; }
    }
}

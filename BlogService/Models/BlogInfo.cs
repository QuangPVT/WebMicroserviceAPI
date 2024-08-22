using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogService.Models
{
    [Table("Blog_Info")]
    public class BlogInfo
    {
        [Key]
        [Column("blog_id")]
        [MaxLength(10)]
        public string BlogId { get; set; }

        [Required]
        [Column("type_id")]
        [MaxLength(20)]
        public string TypeId { get; set; }


        [Required]
        [Column("context")]
        public string Context { get; set; }

        [Required]
        [Column("tag_search")]
        public string TagSearch { get; set; }

        [Required]
        [Column("keyword_seo")]
        public string KeywordSeo { get; set; }

        [Required]
        [Column("description_seo")]
        public string DescriptionSeo { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        [Column("role_id")]
        [MaxLength(10)]
        public string RoleId { get; set; }

        [Column("detail")]
        [MaxLength(100)]
        public string Detail { get; set; }

    }
}

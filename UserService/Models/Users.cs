using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [Column("user_id")]
        [MaxLength(10)]
        public string UserId { get; set; }

        [Required]
        [Column("role_id")]
        [MaxLength(10)]
        public string RoleId { get; set; }


        [Required]
        [Column("usename")]
        [MaxLength(50)]
        public string Usename { get; set; }

        [Required]
        [Column("password")]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [Column("status")]
        public bool Status { get; set; }

    }
}

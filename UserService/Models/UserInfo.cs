using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    [Table("User_Info")]

    public class UserInfo
    {
        [Key]
        [Column("user_id")]
        [MaxLength(10)]
        public string UserId { get; set; }

        [Required]
        [Column("full_name")]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [Column("phone")]
        [MaxLength(12)]
        public string Phone { get; set; }

        [Column("email")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Column("address")]
        [MaxLength(150)]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

    }
}

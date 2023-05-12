using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SodaPop.Models
{
    [Table("Tbl_Login")]
    public class Login
    {
        [Key]
        [Column("id_login")]
        public int Id { get; set; }

        [Column("user_login")]
        [MaxLength(80)]
        [MinLength(2)]
        [NotNull]
        public string Username { get; set; }

        [Column("password_login")]
        [MaxLength(80)]
        [MinLength(5)]
        [NotNull]
        public string Password { get; set; }

        public User? UserLogin { get; set; }
    }
}

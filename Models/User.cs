using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SodaPop.Models
{
    [Table("Tbl_User")]
    public class User
    {
        [Key]
        [Column("id_user")]
        public int Id { get; set; }

        [Column("username")]
        [MaxLength(80)]
        [MinLength(2)]
        public string Username { get; set; }

        [Column("title_user")]
        [MaxLength(40)]
        [MinLength(5)]
        public string TitleUser { get; set; }

        [Column("description_user")]
        [MaxLength(80)]
        [MinLength(5)]
        public string DescriptionUser { get; set; }

        [Column("avatar_user")]
        [MaxLength(80)]
        public string AvatarUser { get; set; }

        [Column("banner_user")]
        [MaxLength(80)]
        public string BannerUser { get; set; }

        [Column("average_user_score")]
        public double AverageUserScore { get; set; }

        [Column("favorite_piece")]
        [MaxLength(80)]
        public string FavoritePiece { get; set; }

        [Column("worst_piece")]
        [MaxLength(80)]
        public string WorstPiece { get; set; }

        [Column("hated_character")]
        [MaxLength(80)]
        public string HatedCharacter { get; set; }

        [Column("lovely_character")]
        [MaxLength(80)]
        public string LovelyCharacter { get; set; }


    }
}

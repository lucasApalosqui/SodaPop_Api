using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SodaPop.Models
{
    [Table("Tbl_User_Piece")]
    public class UserPiece
    {
        public int PieceId { get; set; }
        public int UserId { get; set; }

        [Column("score")]
        public double Score { get; set; }

        [Column("review")]
        [MaxLength(400)]
        public string review { get; set; }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SodaPop.Models
{
    [Table("Tbl_Character")]
    public class Character
    {
        [Key]
        [Column("id_character")]
        public int Id { get; set; }

        [Column("image_character")]
        [MaxLength(80)]
        public string ImageCharacter { get; set; }

        [Column("character_name")]
        [MaxLength(80)]
        public string CharacterName { get; set; }
    }
}

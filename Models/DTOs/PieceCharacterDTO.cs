using System.Collections.Generic;

namespace SodaPop.Models.DTOs
{
    public class PieceCharacterDTO
    {
        public ICollection<CharacterDTO> Characters { get; set; }
    }
}

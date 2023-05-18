using System;
using System.Collections.Generic;

namespace SodaPop.Models.DTOs
{
    public class PieceDTO
    {
        public int IdPiece { get; set; }
        public string PieceName { get; set; }
        public string PieceType { get; set; }
        public string ImageBanner { get; set; }
        public string ImageFront { get; set; }
        public double AverageScore { get; set; }
        public string DescriptionPiece { get; set; }
        public DateTime DateRelease { get; set; }
        public string Duration { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime DatePublish { get; set; }
        public ICollection<CharacterDTO> Characters { get; set; }
    }
}

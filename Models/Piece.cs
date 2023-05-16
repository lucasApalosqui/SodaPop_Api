using BCrypt.Net;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace SodaPop.Models
{
    [Table("Tbl_Piece")]
    public class Piece
    {
        [Key]
        [Column("id_piece")]
        public int IdPiece { get; set; }

        [Column("piece_name")]
        [MaxLength(80)]
        public string PieceName { get; set; }

        [Column("piece_type")]
        [MaxLength(40)]
        public string PieceType { get; set; }

        [Column("image_banner")]
        [MaxLength(80)]
        public string ImageBanner { get; set; }

        [Column("image_front")]
        [MaxLength(80)]
        public string ImageFront { get; set; }

        [Column("average_score")]
        public double AverageScore { get; set; }

        [Column("description_piece")]
        [MaxLength(400)]
        public string DescriptionPiece { get; set; }

        [Column("date_release")]
        public DateTime DateRelease { get; set; }

        [Column("duration")]
        [MaxLength(40)]
        public string Duration { get; set; }

        [Column("director")]
        [MaxLength(40)]
        public string Director { get; set; }

        [Column("producer")]
        [MaxLength(80)]
        public string Producer { get; set; }

        [Column("date_publish")]
        public DateTime DatePublish { get; set; }

        public ICollection<Character> Characters { get; set; }

        public List<User> Users { get; } = new();



    }
}
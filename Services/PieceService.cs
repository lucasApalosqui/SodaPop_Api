using Microsoft.EntityFrameworkCore;
using SodaPop.Context;
using SodaPop.Models;
using SodaPop.Models.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SodaPop.Services
{
    public class PieceService : IPieceService
    {

        private readonly AppDbContext _context;

        public PieceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Piece> GetPieceByIdForDelete(int id)
        {
            try
            {
                var piece = await _context.Tbl_Piece.FirstOrDefaultAsync(p => p.IdPiece == id);
                return piece;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeletePiece(Piece piece)
        {
            try
            {
                _context.Tbl_Piece.Remove(piece);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Get all pieces
        public async Task<IEnumerable<PieceDTO>> GetAllPieces()
        {
            try
            {
                var pieceDTO = _context.Tbl_Piece
                    .Include(p => p.Characters)
                    .Select(p => new PieceDTO
                    {
                        IdPiece = p.IdPiece,
                        AverageScore = p.AverageScore,
                        DatePublish = p.DatePublish,
                        DateRelease = p.DateRelease,
                        DescriptionPiece = p.DescriptionPiece,
                        Director = p.Director,
                        Duration = p.Duration,
                        ImageBanner = p.ImageBanner,
                        ImageFront = p.ImageFront,
                        PieceName = p.PieceName,
                        PieceType = p.PieceType,
                        Producer = p.Producer,
                        Characters = p.Characters.Select(c => new CharacterDTO { 
                            Id = c.Id, 
                            CharacterName = c.CharacterName,
                            ImageCharacter = c.ImageCharacter}).ToList()
                    }).ToListAsync();
                return await pieceDTO;

            }
            catch (Exception)
            {

                throw;
            }
            

        }


        // Get Piece By Id
        public async Task<PieceDTO> GetPieceById(int Id)
        {
            try
            {

                Piece piece = await _context.Tbl_Piece
                    .Include(p => p.Characters)
                    .FirstOrDefaultAsync(p => p.IdPiece == Id);
                if (piece == null)
                {
                    return null;
                }
                
                PieceDTO pieceDTO = new PieceDTO
                {
                    IdPiece = piece.IdPiece,
                    AverageScore = piece.AverageScore,
                    DatePublish = piece.DatePublish,
                    DateRelease = piece.DateRelease,
                    DescriptionPiece = piece.DescriptionPiece,
                    Director = piece.Director,
                    Duration = piece.Duration,
                    ImageBanner = piece.ImageBanner,
                    ImageFront = piece.ImageFront,
                    PieceName = piece.PieceName,
                    PieceType = piece.PieceType,
                    Producer = piece.Producer,
                    Characters = piece.Characters.Select(c => new CharacterDTO
                    {
                        Id = c.Id,
                        CharacterName = c.CharacterName,
                        ImageCharacter = c.ImageCharacter
                    }).ToList()

                };
                return pieceDTO;


            }
            catch (Exception)
            {

                throw;

            }

        }

        // get Pieces by descending most rated
        public async Task<IEnumerable<PieceDTO>> GetPiecesByMostRated()
        {
            try
            {
                IEnumerable<PieceDTO> piecesOrder = await GetAllPieces();
                piecesOrder = piecesOrder.OrderByDescending(p => p.AverageScore);
                return piecesOrder;
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        public async Task<IEnumerable<PieceDTO>> GetPiecesByName(string name)
        {
            try
            {
                IEnumerable<PieceDTO> piecesByName = await GetAllPieces();
                if (!string.IsNullOrEmpty(name))
                {

                    var piecesDTOByName = await _context.Tbl_Piece
                        .Include(p => p.Characters)
                        .Where(p => p.PieceName.Equals(name))
                        .Select(p => new PieceDTO
                        {
                            IdPiece = p.IdPiece,
                            AverageScore = p.AverageScore,
                            DatePublish = p.DatePublish,
                            DateRelease = p.DateRelease,
                            DescriptionPiece = p.DescriptionPiece,
                            Director = p.Director,
                            Duration = p.Duration,
                            ImageBanner = p.ImageBanner,
                            ImageFront = p.ImageFront,
                            PieceName = p.PieceName,
                            PieceType = p.PieceType,
                            Producer = p.Producer,
                            Characters = p.Characters.Select(c => new CharacterDTO
                            {
                                Id = c.Id,
                                CharacterName = c.CharacterName,
                                ImageCharacter = c.ImageCharacter
                            }).ToList()
                        }).ToListAsync();

                    if (piecesDTOByName != null)
                    {
                        piecesByName = piecesDTOByName;
                    }

                }



                return piecesByName;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IEnumerable<PieceDTO>> GetPiecesByType(string type)
        {
            try
            {
                IEnumerable<PieceDTO> piecesByType = await GetAllPieces();
                if (!string.IsNullOrEmpty(type))
                {

                    var piecesDTOByType = await _context.Tbl_Piece
                        .Include(p => p.Characters)
                        .Where(p => p.PieceType.Equals(type))
                        .Select(p => new PieceDTO
                        {
                            IdPiece = p.IdPiece,
                            AverageScore = p.AverageScore,
                            DatePublish = p.DatePublish,
                            DateRelease = p.DateRelease,
                            DescriptionPiece = p.DescriptionPiece,
                            Director = p.Director,
                            Duration = p.Duration,
                            ImageBanner = p.ImageBanner,
                            ImageFront = p.ImageFront,
                            PieceName = p.PieceName,
                            PieceType = p.PieceType,
                            Producer = p.Producer,
                            Characters = p.Characters.Select(c => new CharacterDTO
                            {
                                Id = c.Id,
                                CharacterName = c.CharacterName,
                                ImageCharacter = c.ImageCharacter
                            }).ToList()
                        }).ToListAsync();

                    if (piecesDTOByType != null)
                    {
                        piecesByType = piecesDTOByType;
                    }

                }

                return piecesByType;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreatePiece(PieceCreateDTO pieceCreateDTO)
        {
            try
            {
                Piece piece = new Piece
                {
                    PieceName = pieceCreateDTO.PieceName,
                    PieceType = pieceCreateDTO.PieceType,
                    ImageBanner = pieceCreateDTO.ImageBanner,
                    ImageFront = pieceCreateDTO.ImageFront,
                    DescriptionPiece = pieceCreateDTO.DescriptionPiece,
                    AverageScore = pieceCreateDTO.AverageScore,
                    Duration = pieceCreateDTO.Duration,
                    Director = pieceCreateDTO.Director,
                    Producer = pieceCreateDTO.Producer,
                    DatePublish = pieceCreateDTO.DatePublish,
                    Characters = pieceCreateDTO.Characters.Select(c => new Character
                    {
                        CharacterName = c.CharacterName,
                        ImageCharacter = c.ImageCharacter
                    }).ToList()
                };
                piece.DateRelease = DateTime.Now;
                _context.Tbl_Piece.Add(piece);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdatePiece(PieceUpdateDTO pieceUpdateDTO)
        {
            try
            {
                Piece piece = new Piece
                {
                    IdPiece = pieceUpdateDTO.IdPiece,
                    PieceName = pieceUpdateDTO.PieceName,
                    PieceType = pieceUpdateDTO.PieceType,
                    ImageBanner = pieceUpdateDTO.ImageBanner,
                    ImageFront = pieceUpdateDTO.ImageFront,
                    DescriptionPiece = pieceUpdateDTO.DescriptionPiece,
                    AverageScore = pieceUpdateDTO.AverageScore,
                    Duration = pieceUpdateDTO.Duration,
                    Director = pieceUpdateDTO.Director,
                    Producer = pieceUpdateDTO.Producer,
                    DatePublish = pieceUpdateDTO.DatePublish
                };
                _context.Entry(piece).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

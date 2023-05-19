using SodaPop.Models;
using SodaPop.Models.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SodaPop.Services
{
    public interface IPieceService
    {
        // Search all pieces in DB - for all pieces in db search
        Task<IEnumerable<PieceDTO>> GetAllPieces();

        // Search Pieces by Id - for dev search, is not present in the website
        Task<PieceDTO> GetPieceById(int id);

        // Search for all pieces that contain the specific name - written search by name
        Task<IEnumerable<PieceDTO>> GetPiecesByName(string name);

        // Search for all pieces that contain the specific type - written search by type
        Task<IEnumerable<PieceDTO>> GetPiecesByType(string type);

        // Search for the pieces with the highest average rating
        Task<IEnumerable<Piece>> GetPiecesByMostRated();

        // Create new piece in a site
        Task CreatePiece(PieceCreateDTO pieceCreateDTO);

        // Update a existing piece in a site
        Task UpdatePiece(Piece piece);

        // Delete a existing piece in a site
        Task DeletePiece(Piece piece);

    }
}

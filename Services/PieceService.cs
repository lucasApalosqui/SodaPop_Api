using Microsoft.EntityFrameworkCore;
using SodaPop.Context;
using SodaPop.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SodaPop.Services
{
    public class PieceService : IPieceService
    {

        private readonly AppDbContext _context;

        public PieceService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreatePiece(Piece piece)
        {
            try
            {
                piece.DateRelease = DateTime.Now;
                _context.Tbl_Piece.Add(piece);
               
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {

                throw;
            }
        }

        // Get all pieces
        public async Task<IEnumerable<Piece>> GetAllPieces()
        {
            try
            {
                return await _context.Tbl_Piece.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }


        // Get Piece By Id
        public async Task<Piece> GetPieceById(int Id)
        {
            try
            {

                return await _context.Tbl_Piece.FindAsync(Id);

            }
            catch (Exception ex)
            {

                throw ex;

            }

        }

        // get Pieces by descending most rated
        public async Task<IEnumerable<Piece>> GetPiecesByMostRated()
        {
            try
            {
                IEnumerable<Piece> piecesOrder = await _context.Tbl_Piece.ToListAsync();
                piecesOrder = piecesOrder.OrderByDescending(p => p.AverageScore);
                return piecesOrder;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }


        public async Task<IEnumerable<Piece>> GetPiecesByName(string name)
        {
            try
            {
                IEnumerable<Piece> piecesByName;
                if (string.IsNullOrEmpty(name))
                {
                    piecesByName = await _context.Tbl_Piece.Where(p => p.PieceName.Equals(name)).ToListAsync();


                }
                else
                {
                    piecesByName = await GetAllPieces();
                }

                return piecesByName;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Piece>> GetPiecesByType(string type)
        {
            try
            {
                IEnumerable<Piece> piecesByType;
                if (string.IsNullOrEmpty(type))
                {
                    piecesByType = await _context.Tbl_Piece.Where(p => p.PieceType.Equals(type)).ToListAsync();
                }
                else
                {
                    piecesByType = await GetAllPieces();
                }
                return piecesByType;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdatePiece(Piece piece)
        {
            try
            {
                _context.Entry(piece).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

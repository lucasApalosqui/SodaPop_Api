using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SodaPop.Models;
using SodaPop.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SodaPop.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PieceController : ControllerBase
    {
        private IPieceService _pieceService;

        public PieceController(IPieceService pieceService)
        {
            _pieceService = pieceService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IAsyncEnumerable<Piece>>> GetAllPiece()
        {
            try
            {
                var pieces = await _pieceService.GetAllPieces();
                return Ok(pieces);
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error while get pieces");
            }
        }

        [HttpGet("GetByName")]
        public async Task<ActionResult<IAsyncEnumerable<Piece>>> GetPieceByName([FromQuery] string name)
        {
            try
            {
                var pieces = await _pieceService.GetPiecesByName(name);
                if (pieces.Count() == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Pieces with {name} is not found!");
                }
                else
                {
                    return Ok(pieces);
                }
            }
            catch
            {

                return StatusCode(StatusCodes.Status400BadRequest, "invalid request");
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Piece>> GetPieceById([FromQuery] int id)
        {
            try
            {
                var piece = await _pieceService.GetPieceById(id);
                if (piece == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"The piece with id {id} is not found");
                }
                else
                {
                    return Ok(piece);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "invalid request");

            }

        }

        [HttpGet("GetByType")]
        public async Task<ActionResult<IAsyncEnumerable<Piece>>> GetPieceByType([FromQuery] string type)
        {
            try
            {
                var pieces = await _pieceService.GetPiecesByType(type);
                if (pieces.Count() == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Pieces with type {type} Not found in catalog");
                }
                else
                {
                    return Ok(pieces);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "invalid request");

            }

        }

        [HttpGet("GetToMostRated")]
        public async Task<ActionResult<IAsyncEnumerable<Piece>>> GetAllToMostRated()
        {
            try
            {
                var pieces = await _pieceService.GetPiecesByMostRated();
                return Ok(pieces);
            }
            catch 
            {
                return StatusCode(StatusCodes.Status400BadRequest, "invalid request");

            }
          

        }


    }
}

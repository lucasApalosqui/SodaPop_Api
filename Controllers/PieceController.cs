using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SodaPop.Models;
using SodaPop.Models.DTOs;
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
        public async Task<ActionResult<IAsyncEnumerable<PieceDTO>>> GetPieceByName([FromQuery] string name)
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
        public async Task<ActionResult<PieceDTO>> GetPieceById([FromQuery] int id)
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
                throw;

            }

        }

        [HttpGet("GetByType")]
        public async Task<ActionResult<IAsyncEnumerable<PieceDTO>>> GetPieceByType([FromQuery] string type)
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
        public async Task<ActionResult<IAsyncEnumerable<PieceDTO>>> GetAllToMostRated()
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

        [HttpPost("Create")]
        public async Task<ActionResult> Create(PieceCreateDTO pieceCreateDTO)
        {
            try
            {

                await _pieceService.CreatePiece(pieceCreateDTO);

                return StatusCode(StatusCodes.Status201Created, "Piece created successfully");
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest, "invalid request");

            }
        }

        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult> UpdatePiece(int id, [FromBody] Piece piece)
        {
            try
            {
                if (piece.IdPiece == id)
                {
                    await _pieceService.UpdatePiece(piece);
                    return StatusCode(StatusCodes.Status200OK, "Piece update successfully");

                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "invalid request");
                }
            }
            catch
            {

                return StatusCode(StatusCodes.Status400BadRequest, "invalid request");
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeletePiece(int id)
        {
            try
            {
                var piece = await _pieceService.GetPieceById(id);
                if (piece != null)
                {
                    //await _pieceService.DeletePiece(piece);
                    return StatusCode(StatusCodes.Status200OK, "Piece Deleted Successfully");

                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Invalid request");
                }
            }
            catch
            {

                return StatusCode(StatusCodes.Status400BadRequest, "Invalid request");
            }
        }


    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SodaPop.Models;
using SodaPop.Models.DTOs;
using SodaPop.Services;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace SodaPop.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private ICharacterService _service;

        public CharacterController(ICharacterService service)
        {
            _service = service;


        }



        [HttpGet("GetAll")]

        public async Task<ActionResult<IAsyncEnumerable<CharacterDTO>>> GetAllCharacters()
        {
            try
            {
                var characters = _service.GetAllCharacters();

                return Ok(characters);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while get characters");
            }
        }

        [HttpDelete("DeletePiece")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            try
            {
                var character = await _service.GetCharacterForDelete(id);
                if (character != null)
                {
                    await _service.DeleteCharacter(character);
                    return StatusCode(StatusCodes.Status200OK, "Character Deleted Successfully");
                }

                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Invalid request");
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}

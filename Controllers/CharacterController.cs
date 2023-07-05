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
    }
}

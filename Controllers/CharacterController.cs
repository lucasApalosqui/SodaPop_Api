﻿using Microsoft.AspNetCore.Http;
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


        [HttpDelete("DeleteCharacter")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            try
            {
                Character character = await _service.GetCharacterForDelete(id);
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

        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult> UpdateCharacter(int id, [FromBody] CharacterUpdateDTO character)
        {
            try
            {
                if (character.Id == id)
                {
                    await _service.UpdateCharacter(character);
                    return StatusCode(StatusCodes.Status200OK, "Character update successfully");
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "invalid request");
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}

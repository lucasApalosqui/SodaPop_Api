using Microsoft.EntityFrameworkCore;
using SodaPop.Context;
using SodaPop.Models;
using SodaPop.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace SodaPop.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly AppDbContext _context;

        public CharacterService(AppDbContext context)
        {
            _context = context;
        }


        public async Task UpdateCharacter(CharacterUpdateDTO characterUpdateDTO)
        {
            try
            {
                Character character = new Character
                {
                    IdPiece = characterUpdateDTO.IdPiece,
                    Id = characterUpdateDTO.Id,
                    CharacterName = characterUpdateDTO.CharacterName,
                    ImageCharacter = characterUpdateDTO.ImageCharacter
                };

                _context.Entry(character).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Character> GetCharacterForDelete(int id)
        {
            try
            {
                var character = await _context.Tbl_Character.FirstOrDefaultAsync(c => c.Id == id);
                return character;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task DeleteCharacter(Character character)
        {
            try
            {
                _context.Tbl_Character.Remove(character);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}

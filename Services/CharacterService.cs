﻿using Microsoft.EntityFrameworkCore;
using SodaPop.Context;
using SodaPop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            try
            {
                return await _context.Tbl_Character.ToListAsync();

            }
            catch
            {

                throw;
            }
        }

        public async Task<Character> GetCharacterById(int id)
        {
            try
            {
                return await _context.Tbl_Character.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Character>> GetByPiece(int id)
        {
            try
            {
                return await _context.Tbl_Character.Where(c => c.IdPiece == id).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Character>> GetCharacterByName(string name)
        {
            try
            {
                return await _context.Tbl_Character.Where(c => c.CharacterName == name).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateCharacter(Character character)
        {
            try
            {
                _context.Entry(character).State = EntityState.Modified;
                await  _context.SaveChangesAsync();
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
                _context.Remove(character);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}
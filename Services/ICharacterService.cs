﻿using SodaPop.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SodaPop.Services
{
    public interface ICharacterService
    {
        Task<IEnumerable<Character>> GetAllCharacters();

        Task<Character> GetCharacterById(int id);

        Task<IEnumerable<Character>> GetCharacterByName(string name);

        Task<IEnumerable<Character>> GetByPiece(int id);

        Task UpdateCharacter(Character character);

        Task DeleteCharacter(Character character);


    }
}
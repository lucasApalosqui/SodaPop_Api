using SodaPop.Models;
using SodaPop.Models.DTOs;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SodaPop.Services
{
    public interface ICharacterService
    {

        Task UpdateCharacter(CharacterUpdateDTO characterUpdateDTO);

        Task DeleteCharacter(Character character);

        Task<Character> GetCharacterForDelete(int id);


    }
}

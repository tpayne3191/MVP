using System.Collections.Generic;
using Capstone.Core.Entities;

namespace Capstone.Core.Interfaces
{
    public interface ICharacterWeaponRepository
    {
        Result Create(CharacterWeapon model);
        Result<List<CharacterWeapon>> ReadAll();
        Result<CharacterWeapon> ReadById(int characterId, int weaponId);
        Result Update(CharacterWeapon model);
        Result Delete(int characterId, int weaponId);
    }
}
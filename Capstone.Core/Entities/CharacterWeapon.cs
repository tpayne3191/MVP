using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Core.Entities
{
    public class CharacterWeapon
    {
        public int WeaponId { get; set; }
        public int CharacterId { get; set; }
        public int Quantity { get; set; }
    }
}

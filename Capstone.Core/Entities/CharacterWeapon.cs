using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Capstone.Core.Entities
{
    public class CharacterWeapon
    {
        [Required]
        public int Quantity { get; set; }

        // Parent Connectors - Entity Framework
        [Required]
        public int WeaponId { get; set; }
        public Weapon Weapon { get; set; }

        [Required]
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}


using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Core.Entities
{
    public class Weapon
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Damage { get; set; }

        [Required]
        public int Range { get; set; }

        [Required]
        public string Description { get; set; }

        // Bridge Connectors - Entity Framework
        public List<CharacterWeapon> CharacterWeapons { get; set; }
    }
}
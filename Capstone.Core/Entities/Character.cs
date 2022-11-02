using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Core.Entities
{
    public class Character
    {
        // IDs
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int CampaignId { get; set; }

        // About 
        public int Level { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public string Race { get; set; }
        public string Alignment { get; set; }
        public string Class { get; set; }
        public string Image { get; set; }

        // Stats
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public List<CharacterWeapon> CharacterWeapons { get; set; }
    }
}
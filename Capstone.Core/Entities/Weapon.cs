
using System.Collections.Generic;

namespace Capstone.Core.Entities
{
    public class Weapon
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public string Description { get; set; }
        public List<Character> Characters { get; set; }
    }
}
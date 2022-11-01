
namespace Capstone.Core.Entities
{
    /**
     * <summary>
     *      Summary:
     *      Class to define the weapons object
     * </summary>
     */
    public class Weapons
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Range { get; set; }
        public string Description { get; set; }
    }
}
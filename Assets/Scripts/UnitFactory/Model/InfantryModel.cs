namespace Asteroids.UnitFactory
{
    public sealed class InfantryModel
    {
        public int Health { get; private set; }
        public string Name { get; private set; }
        public InfantryModel(int health, string name)
        {
            Health = health;
            Name = name;
        }
    }
}
namespace Asteroids.UnitFactory
{
    public sealed class MagModel
    {
        public int Health { get; private set; }
        public string Name { get; private set; }
        public MagModel(int health, string name) 
        {
            Health = health;
            Name = name;
        }
    }
}

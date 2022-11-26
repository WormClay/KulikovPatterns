using UnityEngine;
namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(EnemyHealth hp, float damagePower)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Asteroid"));
            enemy.Init(hp, damagePower);
            return enemy;
        }
    }
}

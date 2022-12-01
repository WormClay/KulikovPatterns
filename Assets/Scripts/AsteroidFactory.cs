using UnityEngine;
namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        private EnemyHealth _health;
        private float _damagePower;

        public AsteroidFactory(EnemyHealth hp, float damagePower) 
        {
            _health = hp;
            _damagePower = damagePower;
        }

        public Enemy Create()
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Asteroid"));
            enemy.Init(_health.DeepCopy(), _damagePower.DeepCopy());
            return enemy;
        }
    }
}

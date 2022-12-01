using UnityEngine;
namespace Asteroids
{
    internal sealed class EnemyShipFactory : IEnemyFactory
    {
        private EnemyHealth _health;
        private float _damagePower;

        public EnemyShipFactory(EnemyHealth hp, float damagePower)
        {
            _health = hp;
            _damagePower = damagePower;
        }

        public Enemy Create()
        {
            var enemy = Object.Instantiate(Resources.Load<EnemyShip>("EnemyShip"));
            enemy.Init(_health.DeepCopy(), _damagePower.DeepCopy());
            return enemy;
        }
    }
}


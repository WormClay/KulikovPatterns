using UnityEngine;
namespace Asteroids
{
    internal sealed class EnemyShipFactory : IEnemyFactory
    {
        public Enemy Create(EnemyHealth hp, float damagePower)
        {
            var enemy = Object.Instantiate(Resources.Load<EnemyShip>("EnemyShip"));
            enemy.Init(hp, damagePower);
            return enemy;
        }
    }
}


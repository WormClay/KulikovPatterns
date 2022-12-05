using UnityEngine;
namespace Asteroids
{
    internal sealed class EnemyShipFactory : IEnemyFactory
    {
        private string _pefabName = "EnemyShip";
        public Enemy Create(EnemyHealth hp, float damagePower)
        {
            var enemy = Object.Instantiate(Resources.Load<EnemyShip>(_pefabName));
            enemy.Init(hp, damagePower);
            return enemy;
        }
    }
}


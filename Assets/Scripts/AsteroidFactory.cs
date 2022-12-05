using UnityEngine;
namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        private string _pefabName = "Asteroid";
        public Enemy Create(EnemyHealth hp, float damagePower)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>(_pefabName));
            enemy.Init(hp, damagePower);
            return enemy;
        }
    }
}

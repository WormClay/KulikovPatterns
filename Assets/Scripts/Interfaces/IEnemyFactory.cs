using UnityEngine;

namespace Asteroids
{
    public interface IEnemyFactory
    {
        Enemy Create(float damagePower, EnemyHealth hp, Vector3 position);
    }
}

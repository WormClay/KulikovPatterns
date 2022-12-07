using System.Collections;
using UnityEngine;

namespace Asteroids
{
    public sealed class EnemyShip : Enemy
    {
        public EnemyShip(float damagePower, EnemyHealth hp, int pointsForDie, EnemyView prefab, Vector3 position, Transform parent)
            : base(hp, damagePower, pointsForDie, prefab, position, parent)
        {
        }
    }
}

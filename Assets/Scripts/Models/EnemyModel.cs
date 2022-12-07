using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    public class EnemyModel
    {
        public float DamagePower { get; private set; }
        public EnemyHealth Health { get;}
        public int PointsForDie { get; private set; }
        public EnemyModel(EnemyHealth health, float damagePower, int pointsForDie) 
        {
            DamagePower = damagePower;
            Health = health;
            PointsForDie = pointsForDie;
        }
    }
}

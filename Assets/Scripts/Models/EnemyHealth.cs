using System;

namespace Asteroids
{
    [Serializable]
    public sealed class EnemyHealth
    {
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }
        public EnemyHealth(float hp)
        {
            MaxHealth = hp;
            CurrentHealth = hp;
        }

        public bool Damage(float damage)
        {
            CurrentHealth -= damage;
            return CurrentHealth <= 0;
        }
    }
}

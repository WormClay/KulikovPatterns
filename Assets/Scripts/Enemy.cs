using UnityEngine;
namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour, IDamage
    {
        //public static IEnemyFactory Factory;
        public float DamagePower { get; private set; }
        public EnemyHealth Health { get; protected set; }
        public static Asteroid CreateAsteroidEnemy(EnemyHealth hp, float damagePower)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Asteroid"));
            enemy.Init(hp, damagePower);
            return enemy;
        }

        public static EnemyShip CreateEnemyShip(EnemyHealth hp, float damagePower)
        {
            var enemy = Instantiate(Resources.Load<EnemyShip>("EnemyShip"));
            enemy.Init(hp, damagePower);
            return enemy;
        }

        public void Init(EnemyHealth hp, float damagePower)
        {
            Health = hp;
            DamagePower = damagePower;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamage damageOwner))
            {
                if (Health.Damage(damageOwner.DamagePower))
                    Destroy(gameObject);
            }
            if (other.gameObject.TryGetComponent(out Player _))
            {
                    Destroy(gameObject);
            }
        }

    }
}


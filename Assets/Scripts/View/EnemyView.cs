using System;
using UnityEngine;
namespace Asteroids
{
    public class EnemyView : MonoBehaviour, IDamage
    {
        public float DamagePower { get; set; }
        public event Action<float> EventDamage;
        public event Action EventDestroy;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamage damageOwner))
            {
                EventDamage?.Invoke(damageOwner.DamagePower);
            }
            if (other.gameObject.TryGetComponent(out Player _))
            {
                Destroy(gameObject);
            }
        }
        private void OnDestroy()
        {
            EventDestroy?.Invoke();
        }
    }
}

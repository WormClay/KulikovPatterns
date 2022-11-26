using System.Collections;
using UnityEngine;

namespace Asteroids
{
    public sealed class EnemyShip : Enemy
    {
        private float _lifeTime = 4f;

        private void Start()
        {
            StartCoroutine(Life());
        }

        IEnumerator Life()
        {
            yield return new WaitForSeconds(_lifeTime);
            Destroy(gameObject);
        }
    }
}

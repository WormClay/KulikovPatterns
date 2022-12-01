using System.Collections;
using UnityEngine;
using System;

namespace Asteroids
{
    public sealed class Asteroid : Enemy
    {
        private float _lifeTime = 3f;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class BulletScript: MonoBehaviour
    {
        [SerializeField] private float _lifeTime;

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

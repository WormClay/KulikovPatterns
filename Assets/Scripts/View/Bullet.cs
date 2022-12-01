using System.Collections;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Bullet : MonoBehaviour, IBullet, IDamage
    {
        [SerializeField] private float _lifeTime;
        private Rigidbody2D rigidbody2D;
        private PoolObjectForBuilder poolObject;
        [SerializeField] private float _damagePower;
        public float DamagePower { get { return _damagePower; }  }

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            gameObject.TryGetComponent(out poolObject);
        }

        public void Go(Vector3 direction)
        {
            rigidbody2D.AddForce(direction);
            StartCoroutine(Life());
        }

        IEnumerator Life()
        {
            yield return new WaitForSeconds(_lifeTime);
            Recycle();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Recycle();
        }

        private void Recycle()
        {
            StopCoroutine(Life());
            poolObject?.Recycle();
        }

        public void Init(float lifeTime, float damagePower) 
        {
            _lifeTime = lifeTime;
            _damagePower = damagePower;
        }
    }
}

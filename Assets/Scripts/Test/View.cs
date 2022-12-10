using System;
using UnityEngine;
namespace Test
{
    public class View : MonoBehaviour
    {
        public event Action EventDestroy;
        private void OnCollisionEnter2D(Collision2D other)
        {
            Destroy(gameObject);
        }
        private void OnDestroy()
        {
            EventDestroy?.Invoke();
        }
    }
}

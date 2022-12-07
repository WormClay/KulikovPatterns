using UnityEngine;
namespace Asteroids
{
    internal abstract class BaseUI : MonoBehaviour
    {
        public abstract void Execute();
        public abstract void Cancel();
    }
}

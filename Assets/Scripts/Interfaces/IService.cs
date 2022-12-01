using UnityEngine;
namespace Asteroids
{
    public interface IService
    {
        public PoolObjectForBuilder Get(Transform transform);
    }
}

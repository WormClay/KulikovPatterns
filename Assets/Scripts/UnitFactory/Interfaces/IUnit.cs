using UnityEngine;
namespace Asteroids.UnitFactory
{
    public interface IUnit
    {
        public void Go(Vector3 direction);
        public void Atack();
    }
}

using UnityEngine;
namespace Asteroids
{
    public sealed class ShootingController : IExecute
    {
        private IFire _fireOwner;

        public ShootingController(IFire fireOwner)
        {
            _fireOwner = fireOwner;
        }

        public void Execute()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _fireOwner.Fire();
            }

        }
    }
}

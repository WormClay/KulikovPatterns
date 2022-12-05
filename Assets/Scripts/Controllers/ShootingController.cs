using UnityEngine;
namespace Asteroids
{
    public sealed class ShootingController : IExecute
    {
        private IFire _fireOwner;
        private IUnlock _unlockWeapon;

        public ShootingController(IFire fireOwner, IUnlock unlockWeapon)
        {
            _fireOwner = fireOwner;
            _unlockWeapon = unlockWeapon;
        }

        public void Execute()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _fireOwner.Fire();
            }
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                _unlockWeapon.IsUnlock = !_unlockWeapon.IsUnlock;
            }
        }
    }
}

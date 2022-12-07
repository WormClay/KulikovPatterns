using UnityEngine;

namespace Asteroids
{
    public sealed class WeaponProxy : IFire
    {
        private readonly IFire _weapon;
        private readonly UnlockWeapon _unlockWeapon;
        public WeaponProxy(IFire weapon, UnlockWeapon unlockWeapon)
        {
            _weapon = weapon;
            _unlockWeapon = unlockWeapon;
        }
        public void Fire()
        {
            if (_unlockWeapon.IsUnlock)
            {
                _weapon.Fire();
            }
            else
            {
                Debug.Log("Weapon is lock! To unlock press Space button");
            }
        }
    }
}

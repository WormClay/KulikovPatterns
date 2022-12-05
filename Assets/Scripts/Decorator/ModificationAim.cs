using UnityEngine;
namespace Asteroids.Decorator
{
    internal sealed class ModificationAim : ModificationWeapon
    {
        private readonly IAim _aim;
        //private readonly Vector3 _aimPosition;
        private GameObject _aimGameObject;
        public ModificationAim(IAim aim/*, Vector3 aimPosition*/)
        {
            _aim = aim;
            //_aimPosition = aimPosition;
        }
        protected override Weapon AddModification(Weapon weapon)
        {
            if (!IsModified)
            {
                _aimGameObject = Object.Instantiate(_aim.AimInstance, _aim.BarrelPositionAim.position, Quaternion.identity);
            }
            return weapon;
        }
        protected override Weapon RemoveModification(Weapon weapon)
        {
            if (IsModified)
            {
                Object.Destroy(_aimGameObject);
            }
            return weapon;
        }
    }
}

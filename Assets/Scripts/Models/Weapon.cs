using UnityEngine;

namespace Asteroids
{
    public sealed class Weapon : IFire
    {
        private GameSettings _mainSettings;
        private PoolContainer _bulletsPool;
        private Transform _barrel;
        private float _force;

        public Weapon(GameSettings mainSettings, Transform barrel, float force) 
        {
            _mainSettings = mainSettings;
            _barrel = barrel;
            _force = force;
            _bulletsPool = new PoolContainer(_mainSettings.BulletName, _mainSettings.BulletRootName, 10);
        }

        public void Fire()
        {
            var temAmmunition = _bulletsPool.Get(_barrel);
            if (temAmmunition.TryGetComponent(out IBullet bullet))
            {
                bullet.Go(_barrel.up * _force);
            }

        }
    }
}
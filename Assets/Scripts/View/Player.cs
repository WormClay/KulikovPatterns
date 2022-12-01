using UnityEngine;
namespace Asteroids
{
    internal sealed class Player : MonoBehaviour, IFire
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        [SerializeField] private GameSettings _mainSettings;

        private Ship _ship;
        public InputController InputControllerProp { get; private set; }
        public ShootingController ShootingControllerProp { get; private set; }
        private PlayerHealth _playerHealth;
        //private PoolContainer _bulletsPool;

        private void Awake()
        {
            var moveBody = new AccelerationMove(transform.GetComponent<Rigidbody2D>(), _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveBody, rotation);
            InputControllerProp = new InputController(_ship, transform);
            ShootingControllerProp = new ShootingController(this);
            _playerHealth = new PlayerHealth(_hp);
            //_bulletsPool = new PoolContainer(_mainSettings.BulletName, _mainSettings.BulletRootName, 10);
            ServiceLocator.SetService<IService>(new PoolContainerForBuilder(_mainSettings.SpriteBulletPath, _mainSettings.BulletRootName, 10));
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamage damageOwner))
            {
                if (_playerHealth.Damage(damageOwner.DamagePower))
                    gameObject.SetActive(false);
            }
        }

        public void Fire()
        {
            //var temAmmunition = _bulletsPool.Get(_barrel);
            var temAmmunition = ServiceLocator.Resolve<IService>().Get(_barrel);
            if (temAmmunition.TryGetComponent(out IBullet bullet))
            {
                bullet.Go(transform.up * _force);
            }
        }
    }
}

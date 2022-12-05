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
        private Weapon _weapon;
        private UnlockWeapon _unlockWeapon;
        private WeaponProxy _weaponProxy;

        private void Awake()
        {
            var moveBody = new AccelerationMove(transform.GetComponent<Rigidbody2D>(), _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveBody, rotation);
            _weapon = new Weapon(_mainSettings, _barrel, _force);
            _unlockWeapon = new UnlockWeapon(false);
            _weaponProxy = new WeaponProxy(_weapon, _unlockWeapon);
            InputControllerProp = new InputController(_ship, transform);
            ShootingControllerProp = new ShootingController(this, _unlockWeapon);
            _playerHealth = new PlayerHealth(_hp);
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
            _weaponProxy.Fire();
        }
    }
}

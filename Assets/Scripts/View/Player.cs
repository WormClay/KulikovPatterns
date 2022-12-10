using UnityEngine;
using TMPro;
namespace Asteroids
{
    public sealed class Player : MonoBehaviour, IFire, IExecute
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
        private IState _state;
        private TMP_Text _textState;

        private void Awake()
        {
            var moveBody = new AccelerationMove(transform.GetComponent<Rigidbody2D>(), _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveBody, rotation);
            _weapon = new Weapon(_mainSettings, _barrel, _force);
            _unlockWeapon = new UnlockWeapon(true);
            _weaponProxy = new WeaponProxy(_weapon, _unlockWeapon);
            InputControllerProp = new InputController(_ship, transform);
            ShootingControllerProp = new ShootingController(this, _unlockWeapon);
            _playerHealth = new PlayerHealth(_hp);
            _state = new IdleState(this);
            _textState = GameObject.Find("State").GetComponent<TextMeshProUGUI>();
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

        public void Med(float value) 
        {
            _playerHealth.Med(value);
        }

        public void SetState(IState newState)
        {
            _state = newState;
        }

        public void Execute()
        {
            _state.HandleInput();
            _textState.text = $"State: {_state}";
        }

        public Ship GetShip() => _ship;
    }
}

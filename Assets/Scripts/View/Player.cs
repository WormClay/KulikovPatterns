using UnityEngine;
namespace Asteroids
{
    internal sealed class Player : MonoBehaviour, IFire
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        [SerializeField] private float _damage;

        private Ship _ship;
        public InputController InputControllerProp { get; private set; }
        public ShootingController ShootingControllerProp { get; private set; }
        private PlayerHealth playerHealth;

        private void Awake()
        {
            var moveBody = new AccelerationMove(transform.GetComponent<Rigidbody2D>(), _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveBody, rotation);
            InputControllerProp = new InputController(_ship, transform);
            ShootingControllerProp = new ShootingController(this);
            playerHealth = new PlayerHealth(_hp);
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (playerHealth.Damage(_damage))
                Destroy(gameObject);
        }

        public void Fire()
        {
            var temAmmunition = Instantiate(_bullet, transform.position, transform.rotation);
            temAmmunition.AddForce(transform.up * _force);
        }
    }
}

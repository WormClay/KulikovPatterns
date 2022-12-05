using UnityEngine;
namespace Asteroids.Decorator
{
    internal sealed class Gun : MonoBehaviour
    {
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [Header("Muffler Gun")]
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;
        [Header("Aim Gun")]
        [SerializeField] private GameObject _aim;
        [SerializeField] private Transform _barrelPositionAim;
        private ModificationWeapon _modificationMuffler;
        private ModificationAim _modificationAim;
        private Weapon _weapon;
        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            _weapon = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);
            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPosition, _muffler);
            _modificationMuffler = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
            var aim = new Aim(_barrelPositionAim, _aim);
            _modificationAim = new ModificationAim(aim);
            _fire = _weapon;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                _fire.Fire();
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                if (!_modificationMuffler.IsModified)
                {
                    _modificationMuffler.ApplyModification(_weapon);
                }
                else
                {
                    _modificationMuffler.CancelModification(_weapon);
                }
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                if (!_modificationAim.IsModified)
                {
                    _modificationAim.ApplyModification(_weapon);
                }
                else
                {
                    _modificationAim.CancelModification(_weapon);
                }
            }
        }
    }
}

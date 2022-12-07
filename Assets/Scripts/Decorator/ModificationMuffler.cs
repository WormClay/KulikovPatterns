using UnityEngine;
namespace Asteroids.Decorator
{
    internal sealed class ModificationMuffler : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Vector3 _mufflerPosition;
        private GameObject _mufflerGameObject;
        private float _volumeOriginal;
        private AudioClip _audioClipOriginal;
        private Transform _barrelPositionOriginal;
        public ModificationMuffler(AudioSource audioSource, IMuffler muffler, Vector3 mufflerPosition)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;
        }
        protected override Weapon AddModification(Weapon weapon)
        {
            if (!IsModified)
            {
                _volumeOriginal = weapon.GetVolume();
                _audioClipOriginal = weapon.GetAudioClip();
                _barrelPositionOriginal = weapon.GetBarrelPosition();
                _mufflerGameObject = Object.Instantiate(_muffler.MufflerInstance, _mufflerPosition, Quaternion.identity);
                _audioSource.volume = _muffler.VolumeFireOnMuffler;
                weapon.SetAudioClip(_muffler.AudioClipMuffler);
                weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            }
            return weapon;
        }
        protected override Weapon RemoveModification(Weapon weapon)
        {
            if (IsModified)
            {
                Object.Destroy(_mufflerGameObject);
                _audioSource.volume = _volumeOriginal;
                weapon.SetAudioClip(_audioClipOriginal);
                weapon.SetBarrelPosition(_barrelPositionOriginal);
            }
            return weapon;
        }
    }
}

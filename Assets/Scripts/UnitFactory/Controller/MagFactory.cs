using UnityEngine;

namespace Asteroids.UnitFactory
{
    internal sealed class MagFactory
    {
        private string _prefabName = "Mag";
        private MagView _prefabUnit;
        public MagFactory() 
        {
            _prefabUnit = Resources.Load<MagView>(_prefabName);
        }

        public Mag Create(int health, string name, Vector3 position, Transform parent)
        {
            return new Mag(health, name, position, _prefabUnit, parent);
        }
    }
}

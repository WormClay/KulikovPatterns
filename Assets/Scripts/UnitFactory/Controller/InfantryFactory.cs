using UnityEngine;

namespace Asteroids.UnitFactory
{
    internal sealed class InfantryFactory
    {
        private string _prefabName = "Infantry";
        private InfantryView _prefabUnit;
        public InfantryFactory()
        {
            _prefabUnit = Resources.Load<InfantryView>(_prefabName);
        }

        public Infantry Create(int health, string name, Vector3 position, Transform parent)
        {
            return new Infantry(health, name, position, _prefabUnit, parent);
        }
    }
}
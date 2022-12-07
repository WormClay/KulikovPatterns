using UnityEngine;

namespace Asteroids.UnitFactory
{
    public class Infantry : IUnit
    {
        private InfantryModel _unitData;
        private InfantryView _unitView;
        public Infantry(int health, string name, Vector3 position, InfantryView prefab, Transform parent)
        {
            _unitData = new InfantryModel(health, name);
            _unitView = Object.Instantiate(prefab, position, Quaternion.identity, parent);
            _unitView.gameObject.name = name;
            _unitView.SetTextHealth(health);
        }

        public void Go(Vector3 direction)
        {
            //
        }
        public void Atack()
        {
            //
        }
    }
}

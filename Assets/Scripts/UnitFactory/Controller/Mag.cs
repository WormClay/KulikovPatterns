using UnityEngine;

namespace Asteroids.UnitFactory
{
    public class Mag: IUnit
    {
        private MagModel _unitData;
        private MagView _unitView;
        public Mag(int health, string name, Vector3 position, MagView prefab, Transform parent) 
        {
            _unitData = new MagModel(health, name);
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

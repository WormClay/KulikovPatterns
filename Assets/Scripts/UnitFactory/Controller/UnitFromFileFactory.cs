using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.UnitFactory
{
    public sealed class UnitFromFileFactory
    {
        private MagFactory _magFactory;
        private InfantryFactory _infantryFactory;
        private JsonData<ListSave> _jsonData;
        private float shift = 3f;
        private Transform _parent;
        public UnitFromFileFactory(string path, Transform parent)
        {
            _magFactory = new MagFactory();
            _infantryFactory = new InfantryFactory();
            _jsonData = new JsonData<ListSave>(path);
            _parent = parent;
        }
        public List<IUnit> CreateUnits(string fileName, Vector3 position) 
        {
            Vector3 newPosition = position;
            List<IUnit> list = new List<IUnit>();
            var data = _jsonData.Load(fileName).list;
            if (data != null) 
            {
                foreach (UnitSave el in data) 
                {
                    if (el.unit.type == "mag") 
                    {
                        list.Add(_magFactory.Create(el.unit.health, el.unit.type, newPosition, _parent));
                        newPosition.x += shift;
                    } 
                    else if (el.unit.type == "infantry") 
                    {
                        list.Add(_infantryFactory.Create(el.unit.health, el.unit.type, newPosition, _parent));
                        newPosition.x += shift;
                    } 
                }
                return list;
            } else return null;
        }
    }
}

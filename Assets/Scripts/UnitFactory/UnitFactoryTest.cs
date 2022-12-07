using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Asteroids.UnitFactory
{
    public class UnitFactoryTest : MonoBehaviour
    {
        private UnitFromFileFactory _unitFactory;
        private List<IUnit> _listUnits;
        private string _path;
        private const string _folderName = "DataSave";
        private const string _fileName = "SavedData.dat";
        private void Awake()
        {
            _path = Path.Combine(Application.dataPath, _folderName);
            //Data
            string str = "{\"list\":[{\"unit\":{\"type\":\"mag\",\"health\":100}},{\"unit\":{\"type\":\"infantry\",\"health\":150}},{\"unit\":{\"type\":\"mag\",\"health\":50}}]}";
            //Save data to the file
            File.WriteAllText(Path.Combine(_path, _fileName), str);
        }

        void Start()
        {
            _unitFactory = new UnitFromFileFactory(_path, transform);
            _listUnits = _unitFactory.CreateUnits(_fileName, transform.position);
        }
    }
}

using UnityEngine;
namespace Asteroids
{
    public class DictionaryInInspector : MonoBehaviour
    {
        public DictionaryIntString _myDictionary;

        private void Start()
        {
            _myDictionary = new DictionaryIntString() { { 1, "One" }, { 2, "Two" }, { 3, "three" } };
            _myDictionary.Add(4, "four");
        }

    }
}

using UnityEngine;
namespace Test
{
    public class Test : MonoBehaviour
    {
        [SerializeField] View _prefab;
        void Start()
        {
            Unit unit = new Unit("����� ������ �����", _prefab);
        }
    }
}

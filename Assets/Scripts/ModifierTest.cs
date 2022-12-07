using UnityEngine;
namespace Asteroids
{
    public class ModifierTest : MonoBehaviour
    {
        private PlayerModifier _modifier;
        private Player _player;

        void Start()
        {
            _player = FindObjectOfType<Player>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _modifier = new PlayerModifier(_player);
                _modifier.Add(new AddHealthModifier(_player, 1));
                _modifier.Add(new AddHealthModifier(_player, 2));
                _modifier.Handle();
            }
        }
    } 
}

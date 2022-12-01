using UnityEngine;
namespace Asteroids
{
    internal sealed class GameObjectScriptBuilder : GameObjectBuilder
    {
        public GameObjectScriptBuilder(GameObject gameObject) :
        base(gameObject)
        { }
        public GameObjectScriptBuilder Add<T>() where T : MonoBehaviour
        {
            _gameObject.AddComponent<T>();
            return this;
        }
    }
}
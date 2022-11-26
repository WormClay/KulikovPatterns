using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "NewSettings", menuName = "SO/Settings", order = 51)]
    public sealed class GameSettings : ScriptableObject
    {
        public string SpaceShipName = "SpaceShip";
        public string BulletName = "Bullet";
        public string BulletRootName = "Bullets";
    }
}


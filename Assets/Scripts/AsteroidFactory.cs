using UnityEngine;
namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        private string _pefabName = "Asteroid";
        private EnemyView _prefab;
        private int _pointsForDie;
        private Transform _parent;
        private float _lifeTime;
        public AsteroidFactory(Transform parent, int pointsForDie, float lifeTime) 
        {
            _prefab = Resources.Load<EnemyView>(_pefabName);
            _pointsForDie = pointsForDie;
            _parent = parent;
            _lifeTime = lifeTime;
        }
        public Enemy Create(float damagePower, EnemyHealth hp, Vector3 position)
        {
            Enemy enemy = new Asteroid(damagePower, hp, _pointsForDie, _prefab, position, _parent);
            enemy.DestroyOverTime(_lifeTime);
            return enemy;
        }
    }
}

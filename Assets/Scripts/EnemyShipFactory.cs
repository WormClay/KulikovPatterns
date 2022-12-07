using UnityEngine;
namespace Asteroids
{
    internal sealed class EnemyShipFactory : IEnemyFactory
    {
        private string _pefabName = "EnemyShip";
        private EnemyView _prefab;
        private int _pointsForDie;
        private Transform _parent;
        private float _lifeTime;
        public EnemyShipFactory(Transform parent, int pointsForDie, float lifeTime)
        {
            _prefab = Resources.Load<EnemyView>(_pefabName);
            _pointsForDie = pointsForDie;
            _parent = parent;
            _lifeTime = lifeTime;
        }
        public Enemy Create(float damagePower, EnemyHealth hp, Vector3 position)
        {
            Enemy enemy = new EnemyShip(damagePower, hp, _pointsForDie, _prefab, position, _parent);
            enemy.DestroyOverTime(_lifeTime);
            return enemy;

        }
    }
}


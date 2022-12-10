using System;
using UnityEngine;
using Asteroids.Iterator;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids
{
    public abstract class Enemy : IEnemy, IDie
    {
        public int PointsForDie { get { return _enemyModel.PointsForDie; } }
        public event Action<Enemy> EnemyDied;
        public bool IsKilled { get; protected set; } = false;
        private EnemyView _enemyView;
        private EnemyModel _enemyModel;
        public Enemy(EnemyHealth hp, float damagePower, int pointsForDie, EnemyView prefab, Vector3 position, Transform parent) 
        {
            _enemyView = UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity, parent);
            _enemyView.DamagePower = damagePower;
            _enemyModel = new EnemyModel(hp, damagePower, pointsForDie);
            _enemyView.EventDamage += OnDamage;
            _enemyView.EventDestroy += OnDestroyView;
        }
        private void OnDamage(float damage) 
        {
            if (_enemyModel.Health.Damage(damage))
            {
                IsKilled = true;
                UnityEngine.Object.Destroy(_enemyView.gameObject);
            }
        }
        private void OnDestroyView()
        {
            _enemyView.EventDamage -= OnDamage;
            _enemyView.EventDestroy -= OnDestroyView;
            EnemyDied?.Invoke(this);
        }
        public void DestroyOverTime(float time) 
        {
            UnityEngine.Object.Destroy(_enemyView.gameObject, time);
        }
        public abstract void Activate(IEnemyVisitor value);

        //Iterator

        private List<IAbility> _ability;
        public void SetAbility(List<IAbility> ability)
        {
            _ability = ability;
        }
        public IAbility this[int index] => _ability[index];
        public string this[Target index]
        {
            get
            {
                var ability = _ability.FirstOrDefault(a => a.Target == index);
                return ability == null ? "Not supported" : ability.ToString();
            }
        }
        public int MaxDamage => _ability.Select(a => a.Damage).Max();
        public IEnumerable<IAbility> GetAbility()
        {
            while (true)
            {
                yield return _ability[UnityEngine.Random.Range(0, _ability.Count)];
            }
        }
        public IEnumerator<IAbility> GetEnumerator()
        {
            for (int i = 0; i < _ability.Count; i++)
            {
                yield return _ability[i];
            }
        }
        public IEnumerable<IAbility> GetAbility(DamageType index)
        {
            foreach (IAbility ability in _ability)
            {
                if (ability.DamageType == index)
                {
                    yield return ability;
                }
            }
        }

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyController : IExecute
    {
        private AsteroidFactory _asteroidFactory;
        private EnemyShipFactory _enemyShipFactory;
        private float _lastSpawnerTime = 0f;
        private float _spawnerTimeStep = 1f;
        private PointsController _pointsController;
        private int _pointsForDieAsterod = 350;
        private int _pointsForDieEnemyShip = 1000000;
        private float _enemyLifeTime = 3f;
        private ListenerDie _listenerDie;
        private BirthDisply _birthDisply;

        public EnemyController(PointsController pointsController, Transform parent) 
        {
            _asteroidFactory = new AsteroidFactory(parent, _pointsForDieAsterod, _enemyLifeTime);
            _enemyShipFactory = new EnemyShipFactory(parent, _pointsForDieEnemyShip, _enemyLifeTime);
            _pointsController = pointsController;
            _listenerDie = new ListenerDie();
            _birthDisply = new BirthDisply();
        }


        public void Execute() 
        {
            if ((_lastSpawnerTime + _spawnerTimeStep) < Time.time)
            {
                EnemySpawner();
                _lastSpawnerTime = Time.time;
            }

        }

        /// <summary>
        /// For test only
        /// </summary>
        private void EnemySpawner()
        {
            if (Random.Range(0, 4) != 3)
            {
                var enemy = _asteroidFactory.Create(2, new EnemyHealth(1), new Vector3(Random.Range(-18, 19), 12, 0));
                enemy.EnemyDied += _pointsController.OnEnemyDie;
                _listenerDie.Add(enemy);
                enemy.Activate(_birthDisply);
            }
            else
            {
                var enemy = _enemyShipFactory.Create(5, new EnemyHealth(2), new Vector3(Random.Range(-18, 19), 12, 0));
                enemy.EnemyDied += _pointsController.OnEnemyDie;
                _listenerDie.Add(enemy);
                enemy.Activate(_birthDisply);
            }
        }

    }
}

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

        public EnemyController() 
        {
            _asteroidFactory = new AsteroidFactory();
            _enemyShipFactory = new EnemyShipFactory();
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
                var enemy = _asteroidFactory.Create(new EnemyHealth(1), 2);
                enemy.transform.position = new Vector3(Random.Range(-18, 19), 12, 0);
            }
            else
            {
                var enemy = _enemyShipFactory.Create(new EnemyHealth(2), 5);
                enemy.transform.position = new Vector3(Random.Range(-18, 19), 12, 0);
            }
        }

    }
}

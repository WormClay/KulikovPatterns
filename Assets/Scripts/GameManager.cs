using System.Collections;
using UnityEngine;

namespace Asteroids
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private GameSettings _mainSettings;
        private ListExecute _listExecute;
        private Player _player;
        private AsteroidFactory _asteroidFactory;
        private EnemyShipFactory _enemyShipFactory;
        private float _lastSpawnerTime = 0f;
        private float _spawnerTimeStep = 1f;

        private void Awake()
        {
            _listExecute = new ListExecute();
            _player = Instantiate(Resources.Load<Player>(_mainSettings.SpaceShipName));
            _asteroidFactory = new AsteroidFactory();
            _enemyShipFactory = new EnemyShipFactory();
        }

        private void Start()
        {
            _listExecute.Add(_player.InputControllerProp);
            _listExecute.Add(_player.ShootingControllerProp);
        }

        private void Update()
        {
            foreach (IExecute e in _listExecute.ListObject)
            {
                e.Execute();
            }

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
                var enemy = _asteroidFactory.Create(new EnemyHealth(2), 2);
                enemy.transform.position = new Vector3(Random.Range(-18, 19), 12, 0);
            }
            else
            {
                var enemy = _enemyShipFactory.Create(new EnemyHealth(3), 5);
                enemy.transform.position = new Vector3(Random.Range(-18, 19), 12, 0);
            }
        }
    }
}

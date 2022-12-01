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
            _asteroidFactory = new AsteroidFactory(new EnemyHealth(1), 2);
            _enemyShipFactory = new EnemyShipFactory(new EnemyHealth(2), 5);
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
                _lastSpawnerTime = Time.time;
                EnemySpawner();
            }
        }

        /// <summary>
        /// For test only
        /// </summary>
        private void EnemySpawner() 
        {
            if (Random.Range(0, 4) != 3)
            {
                int a = Random.Range(-18, 19);
                var enemy = _asteroidFactory.Create();
                enemy.transform.position = new Vector3(a, 12, 0);
            }
            else
            {
                var enemy = _enemyShipFactory.Create();
                enemy.transform.position = new Vector3(Random.Range(-18, 19), 12, 0);
            }
        }
    }
}

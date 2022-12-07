using System.Collections;
using UnityEngine;

namespace Asteroids
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private GameSettings _mainSettings;
        private ListExecute _listExecute;
        private Player _player;
        private GameService _gameService;
        private int _startPoints = 0;

        private void Awake()
        {
            _listExecute = new ListExecute();
            _player = Instantiate(Resources.Load<Player>(_mainSettings.SpaceShipName));
            _gameService = new GameService();
        }

        private void Start()
        {
            _gameService.Start(_player, _listExecute, _startPoints, transform);
        }

        private void Update()
        {
            foreach (IExecute e in _listExecute.ListObject)
            {
                e.Execute();
            }
        }
    }
}

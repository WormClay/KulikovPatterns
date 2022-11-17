using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameManager : MonoBehaviour
    {
        private ListExecute _listExecute;
        private Player _player;

        private void Awake()
        {
            _listExecute = new ListExecute();
            _player = Instantiate(Resources.Load<Player>("SpaceShip"));
        }

        private void Start()
        {
            _listExecute.Add(_player.InputControllerProp);
            _listExecute.Add(_player.ShootingControllerProp);
        }

        void Update()
        {
            foreach (IExecute e in _listExecute.ListObject)
            {
                e.Execute();
            }
        }
    }
}

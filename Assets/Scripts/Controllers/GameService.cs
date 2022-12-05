using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameService
    {
        private EnemyController _enemyController;

        public void Start(Player player, ListExecute listExecute)
        {
            _enemyController = new EnemyController();
            listExecute.Add(player.InputControllerProp);
            listExecute.Add(player.ShootingControllerProp);
            listExecute.Add(_enemyController);
        }
    }
}

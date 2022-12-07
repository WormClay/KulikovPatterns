using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameService
    {
        private EnemyController _enemyController;
        private PointsController _pointsController;
        public void Start(Player player, ListExecute listExecute, int startPoints, Transform parent)
        {
            _pointsController = new PointsController(startPoints);
            _enemyController = new EnemyController(_pointsController, parent);
            listExecute.Add(player.InputControllerProp);
            listExecute.Add(player.ShootingControllerProp);
            listExecute.Add(_enemyController);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Asteroids
{
    public class PointsController
    {
        private PointsModel _pointsModel;
        private PointsView _pointsView;
        public PointsController(long startPoints) 
        {
            _pointsModel = new PointsModel(startPoints);
            _pointsView = new PointsView(startPoints);
        }
        public void OnEnemyDie(Enemy enemy) 
        {
            if (enemy.IsKilled)
            {
                _pointsView.SetPoints(CheckPoints(_pointsModel.AddPoints(enemy.PointsForDie)));
            }
            enemy.EnemyDied -= OnEnemyDie;
        }
        private string CheckPoints(long points) 
        {
            if (points < 1000) return points.ToString();
            if (points >= 1000 && points < 1000000) return $"{(points/1000)}K";
            if (points >= 1000000 && points < 1000000000) return $"{(points / 1000000)}M";
            if (points >= 1000000000 && points < 1000000000000) return $"{(points / 1000000000)}MD";
            return points.ToString();
        }
    }
}

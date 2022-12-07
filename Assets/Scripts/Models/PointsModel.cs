using System;
namespace Asteroids
{
    public class PointsModel
    {
        private long _points;
        public PointsModel(long points)
        {
            _points = points;
        }
        public long AddPoints(long points)
        {
            _points += Math.Abs(points);
            return _points;
        }
        public long GetPoints()
        {
            return _points;
        }
    }
}

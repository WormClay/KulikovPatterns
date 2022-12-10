using System;
namespace Asteroids
{
    public interface IDie
    {
        public event Action<Enemy> EnemyDied;
    }
}
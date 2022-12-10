namespace Asteroids
{
    public interface IEnemyVisitor
    {
        void Visit(Asteroid birth);
        void Visit(EnemyShip birth);
    }
}

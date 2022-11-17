namespace Asteroids
{
    public interface IShip: IMove, IRotation
    {
        void AddAcceleration();
        void RemoveAcceleration();
    } 
}

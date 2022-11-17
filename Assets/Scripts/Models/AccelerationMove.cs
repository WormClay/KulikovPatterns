using UnityEngine;
namespace Asteroids
{
    internal sealed class AccelerationMove : MoveForce
    {
        private readonly float _acceleration;
        public AccelerationMove(Rigidbody2D body, float speed, float acceleration)
        : base(body, speed)
        {
            _acceleration = acceleration;
        }
        public void AddAcceleration()
        {
            Speed += _acceleration;
        }
        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}

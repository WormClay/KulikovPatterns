using UnityEngine;
namespace Asteroids
{
    internal class MoveForce : IMove
    {
        private readonly Rigidbody2D _body;
        private Vector2 direction;
        public float Speed { get; protected set; }
        public MoveForce(Rigidbody2D body, float speed)
        {
            _body = body;
            Speed = speed;
        }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            direction.Set(horizontal, vertical); 
            _body.AddForce(direction * speed);
        }
    }
}


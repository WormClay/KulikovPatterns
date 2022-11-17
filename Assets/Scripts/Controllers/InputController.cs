using UnityEngine;

namespace Asteroids
{
    public sealed class InputController : IExecute
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private Camera _camera;
        private IShip _ship;
        private Transform _transform;

        internal InputController(IShip ship, Transform transform)
        {
            _ship = ship;
            _transform = transform;
            _camera = Camera.main;
        }

        public void Execute()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_transform.position);
            _ship.Rotation(direction);
            _ship.Move(Input.GetAxis(Horizontal), Input.GetAxis(Vertical), Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
        }
    }
}


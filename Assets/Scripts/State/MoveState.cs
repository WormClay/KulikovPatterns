using UnityEngine;
namespace Asteroids
{
    public sealed class MoveState : BaseState
    {
        private Ship _ship;
        public MoveState(Player player) : base(player)
        {
            _ship = player.GetShip();
        }

        public override void HandleInput()
        {
            base.HandleInput();
            if (_horizontal == 0 && _vertical == 0)
            {
                _player.SetState(new IdleState(_player));
            }
            _ship.Move(_horizontal, _vertical, Time.deltaTime);
        }
    }
}

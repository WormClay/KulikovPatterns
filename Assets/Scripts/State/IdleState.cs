namespace Asteroids
{
    public sealed class IdleState : BaseState
    {
        public IdleState(Player player) :base(player)  
        {
        }

        public override void HandleInput() 
        {
            base.HandleInput();
            if (_horizontal != 0 || _vertical != 0) 
            {
                _player.SetState(new MoveState(_player));
            }
        }
    }
}

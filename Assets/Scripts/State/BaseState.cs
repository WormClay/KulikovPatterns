namespace Asteroids
{
    public abstract class BaseState : IState
    {
        protected Player _player;
        protected float _horizontal;
        protected float _vertical;
        public BaseState(Player player)
        {
            _player = player;
        }

        public virtual void HandleInput()
        {
            _horizontal = _player.InputControllerProp.GetHorizontal();
            _vertical = _player.InputControllerProp.GetVertical();
        }
    }
}

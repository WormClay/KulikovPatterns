namespace Asteroids
{
    internal sealed class AddHealthModifier : PlayerModifier
    {
        private readonly float _med;
        public AddHealthModifier(Player player, float med)
        : base(player)
        {
            _med = med;
        }
        public override void Handle()
        {
            _player.Med(_med);
            base.Handle();
        }
    }
}
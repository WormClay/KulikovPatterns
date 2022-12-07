namespace Asteroids
{
    public sealed class UnlockWeapon: IUnlock
    {
        public bool IsUnlock { get; set; }
        public UnlockWeapon(bool isUnlock)
        {
            IsUnlock = isUnlock;
        }
    }
}
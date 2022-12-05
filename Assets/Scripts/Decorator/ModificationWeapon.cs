namespace Asteroids.Decorator
{
    internal abstract class ModificationWeapon : IFire
    {
        private Weapon _weapon;
        public bool IsModified { get; private set; } = false;
        protected abstract Weapon AddModification(Weapon weapon);
        protected abstract Weapon RemoveModification(Weapon weapon);
        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
            IsModified = true;
        }
        public void CancelModification(Weapon weapon)
        {
            _weapon = RemoveModification(weapon);
            IsModified = false;
        }
        public void Fire()
        {
            _weapon.Fire();
        }
    }
}

namespace Asteroids
{
    public class PlayerHealth
    {
        private float _maxHealth;
        private float _currentHealth;

        public PlayerHealth(float hp) 
        {
            _maxHealth = hp;
            _currentHealth = hp;
        }

        public bool Damage(float damage)
        {
            _currentHealth -= damage;
            return _currentHealth <= 0;
        }

        public void Med(float value) 
        {
            _currentHealth += value;
            if (_currentHealth > _maxHealth) 
                _currentHealth = _maxHealth;
        }
    }
}

using System;

namespace Asteroids
{
    public class PlayerHealth
    {
        private float _maxHealth;
        private float _currentHealth;
        private UIHealth _uiHelth;

        public PlayerHealth(float hp) 
        {
            _maxHealth = hp;
            _currentHealth = hp;
            _uiHelth = new UIHealth(hp);
        }

        public bool Damage(float damage)
        {
            _currentHealth -= damage;
            _uiHelth.SetHelth(_currentHealth);
            return _currentHealth <= 0;
        }

        public void Med(float value) 
        {
            _currentHealth += Math.Abs(value);
            if (_currentHealth > _maxHealth) 
                _currentHealth = _maxHealth;
            _uiHelth.SetHelth(_currentHealth);
        }
    }
}

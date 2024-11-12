using System;

namespace Model
{
    public class Health : IHealth
    {
        private readonly float _maxHealth;
        private float _currentHealth;

        public bool IsAlive { get; private set; }

        public event Action<float, float> HealthChanged;
        public event Action Died;
        public event Action Relieved;

        public Health(float maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
            IsAlive = true;
        }

        public void ApplyDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentException(nameof(damage));

            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);

            if (_currentHealth <= 0)
            {
                IsAlive = false;
                Died?.Invoke();
            }
        }

        public void Relieve()
        {
            Relieved?.Invoke();
            _currentHealth = _maxHealth;
            IsAlive = true;
        }

        public void UseHeelSpell(float healthForAdd)
        {
            if (_currentHealth + healthForAdd > _maxHealth)
                _currentHealth = _maxHealth;
            else
                _currentHealth += healthForAdd;

            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
}
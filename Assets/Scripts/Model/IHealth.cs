using System;

namespace Model
{
    public interface IHealth
    {
        event Action Died;
        event Action<float, float> HealthChanged;
        event Action Relieved;

        void UseHeelSpell(float healthForAdd);
        void ApplyDamage(float damage);
        void Relieve();
    }
}
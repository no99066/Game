using System;
using UnityEngine;

namespace Model
{
    public class Castle : Entity, ITarget
    {
        public new Vector2 Position { get; }

        public event Action TookDamage;

        public Castle(Vector2 position) : base(Config.CastleHealth)
        {
            Position = position;
        }

        public void ApplyDamage(float damage)
        {
            const int numberOfMultiplyDamage = 10;

            damage *= numberOfMultiplyDamage;
            TookDamage?.Invoke();
            Health.ApplyDamage(damage);
        }
    }
}
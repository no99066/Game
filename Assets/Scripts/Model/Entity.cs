using System;
using UnityEngine;

namespace Model
{
    public abstract class Entity
    {
        private readonly Health _health;

        public bool IsAlive => _health.IsAlive;

        public IHealth Health
        {
            get
            {
                if (_health == null)
                    throw new ArgumentException(Config.HealthMessageException);

                return _health;
            }
        }

        public Vector2 Position { get; protected set; }

        protected Entity()
        {
        }

        protected Entity(float maxHealth)
        {
            _health = new Health(maxHealth);
        }
    }
}
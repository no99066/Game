using UnityEngine;

namespace Model
{
    public interface ITarget
    {
        Vector2 Position { get; }
        bool IsAlive { get; }
        void ApplyDamage(float damage);
    }
}
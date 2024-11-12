using System;
using UnityEngine;

namespace Model.Enemies.States
{
    public abstract class BaseEnemyState
    {
        protected readonly Enemy Enemy;

        public event Action TargetDied;
        public bool IsEnable { get; protected set; }

        protected BaseEnemyState(Enemy enemy)
        {
            Enemy = enemy;
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void TryMoveTo(Vector2 position, float deltaTime);
        public abstract void TryAttack(ITarget target);

        protected void DiedTarget()
        {
            TargetDied?.Invoke();
        }
    }
}
using System;
using System.Linq;
using Model.Enemies.States;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model.Enemies
{
    public abstract class Enemy : Entity, IUpdateable
    {
        private readonly BaseEnemyState[] _states;
        private readonly ITarget[] _targets;
        private ITarget _currentTarget;
        private BaseEnemyState _currentState;

        public event Action<Vector2> Moved;
        public event Action Attacked;

        protected Enemy(ITarget[] targets, Vector2 position) : base(Config.EnemyHealth)
        {
            _targets = targets;
            Position = position;
            _currentTarget = GetAliveTarget();

            _states = new BaseEnemyState[]
            {
                new EnemyAttacking(this, Config.EnemyDamage),
                new EnemyMoving(this, Config.EnemySpeedOfMovement)
            };

            _currentState = _states.FirstOrDefault(state => state is EnemyMoving);
        }

        public void Update(float deltaTime)
        {
            if (_currentTarget == null)
                return;

            if (IsAlive == false)
                return;

            _currentState.TryMoveTo(_currentTarget.Position, deltaTime);
            _currentState.TryAttack(_currentTarget);
        }

        public void MoveTo(Vector2 position)
        {
            Position = position;
            Moved?.Invoke(Position);
        }

        public void SwitchState<T>() where T : BaseEnemyState
        {
            _currentState.Exit();
            _currentState.TargetDied -= OnTargetDied;

            _currentState = _states.FirstOrDefault(state => state is T);

            if (_currentState == null)
                return;

            _currentState.TargetDied += OnTargetDied;
            _currentState.Enter();
        }

        public void Attack()
        {
            Attacked?.Invoke();
        }

        public void ApplyDamage(float damage)
        {
            Health.ApplyDamage(damage);
        }

        private ITarget GetAliveTarget()
        {
            var aliveTargets = _targets.Where(target => target is Hero && target.IsAlive).ToArray();
            return aliveTargets.Length != 0 ? aliveTargets[Random.Range(0, aliveTargets.Length)] : null;
        }

        private void OnTargetDied()
        {
            _currentTarget = _targets.FirstOrDefault(target => target is Castle);
        }
    }
}
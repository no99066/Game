using UnityEngine;

namespace Model.Enemies.States
{
    public class EnemyAttacking : BaseEnemyState
    {
        private readonly float _damage;

        public EnemyAttacking(Enemy enemy, float damage) : base(enemy)
        {
            _damage = damage;
        }

        public override void Enter()
        {
            IsEnable = true;
        }

        public override void Exit()
        {
            IsEnable = false;
        }

        public override void TryMoveTo(Vector2 position, float deltaTime)
        {
        }

        public override void TryAttack(ITarget target)
        {
            if (target.IsAlive)
            {
                Enemy.Attack();
                target.ApplyDamage(_damage);
            }
            else
            {
                DiedTarget();
                Enemy.SwitchState<EnemyMoving>();
            }
        }
    }
}
using UnityEngine;

namespace Model.Enemies.States
{
    public class EnemyMoving : BaseEnemyState
    {
        private readonly float _speedOfMoving;
        private readonly float _range;

        public EnemyMoving(Enemy enemy, float speedOfMoving) : base(enemy)
        {
            _speedOfMoving = speedOfMoving;
            _range = Random.Range(Config.MinDistanceWithTarget, Config.MaxDistanceWithTarget);
        }

        public override void Enter()
        {
            IsEnable = true;
        }

        public override void Exit()
        {
            IsEnable = false;
        }

        public override void TryAttack(ITarget target)
        {
        }

        public override void TryMoveTo(Vector2 position, float deltaTime)
        {
            if (Vector2.Distance(Enemy.Position, position) < _range)
            {
                Enemy.SwitchState<EnemyAttacking>();
                return;
            }

            var newPosition = Vector2.MoveTowards(Enemy.Position, position, _speedOfMoving * deltaTime);
            Enemy.MoveTo(newPosition);
        }
    }
}
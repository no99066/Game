using Model.Enemies;
using Model.Score;
using UnityEngine;
using Views;

namespace Presenters
{
    public class EnemyPresenter : IPresenter
    {
        private readonly Enemy _enemy;
        private readonly EnemyView _enemyView;
        private readonly Score _score;

        public EnemyPresenter(Enemy model, EnemyView view, Score score)
        {
            _enemy = model;
            _enemyView = view;
            _score = score;
        }

        public void Enable()
        {
            _enemy.Health.Died += OnModelDied;
            _enemy.Moved += OnEnemyMoved;
            _enemy.Attacked += OnEnemyAttacked;
            _enemyView.Collided += OnViewCollided;
        }

        public void Disable()
        {
            _enemy.Health.Died -= OnModelDied;
            _enemy.Moved -= OnEnemyMoved;
            _enemy.Attacked -= OnEnemyAttacked;
            _enemyView.Collided -= OnViewCollided;
        }

        private void OnModelDied()
        {
            _enemyView.Died();
            _score.OnEnemyDied();
        }

        private void OnEnemyAttacked()
        {
            _enemyView.Attack();
        }

        private void OnEnemyMoved(Vector2 position)
        {
            _enemyView.Move(position);
        }

        private void OnViewCollided(float damage)
        {
            _enemy.ApplyDamage(damage);
        }
    }
}
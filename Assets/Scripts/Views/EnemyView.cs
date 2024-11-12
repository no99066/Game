using System;
using Spawner;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Animator))]
    public class EnemyView : View, ISpawnable
    {
        private Animator _animator;
        private Transform _transform;

        private readonly int _tryMove = Animator.StringToHash("TryMove");
        private readonly int _tryAttack = Animator.StringToHash("TryAttack");
        private readonly int _tryDie = Animator.StringToHash("TryDie");

        public event Action<float> Collided;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _transform = GetComponent<Transform>();
        }

        public void Move(Vector2 position)
        {
            _animator.SetTrigger(_tryMove);
            _transform.position = position;
        }

        public void Attack()
        {
            _animator.SetTrigger(_tryAttack);
        }

        public void TurnOff()
        {
            _animator.SetTrigger(_tryMove);
            gameObject.SetActive(false);
        }

        public void TurnOn()
        {
            gameObject.SetActive(true);
        }

        public void Collide(float damage)
        {
            Collided?.Invoke(damage);
        }

        public override void Died()
        {
            _animator.SetTrigger(_tryDie);
            Invoke(nameof(TurnOff), 0.5f);
        }
    }
}
using System;
using System.Collections;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Animator))]
    public abstract class HeroView : View
    {
        [SerializeField] private ShootButton _shootButton;

        private Animator _animator;

        private readonly int _tryDie = Animator.StringToHash("TryDie");
        private readonly int _tryRelieve = Animator.StringToHash("TryRelieve");
        private readonly int _tryAttack = Animator.StringToHash("TryAttack");

        public event Action Relieved;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Rage(float speedUp)
        {
            _shootButton.RageOn(speedUp);
        }

        public void RestoreHealth()
        {
        }

        public override void Died()
        {
            _shootButton.OnHeroDied();
            StartCoroutine(WaitingToRelieve());
            TurnOff();
        }

        private void Relieve()
        {
            Relieved?.Invoke();
            _shootButton.OnHeroRelieved();
            TurnOn();
        }

        private void TurnOff()
        {
            _animator.SetTrigger(_tryDie);
        }

        private void TurnOn()
        {
            _animator.SetTrigger(_tryRelieve);
        }

        public void Attack()
        {
            _animator.SetTrigger(_tryAttack);
        }

        private IEnumerator WaitingToRelieve()
        {
            const float delayOfWaitingToRelieve = 7f;
            yield return new WaitForSeconds(delayOfWaitingToRelieve);
            Relieve();
        }
    }
}
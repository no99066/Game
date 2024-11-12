using Model;
using Model.Enemies;
using Model.Score;
using Presenters;
using UnityEngine;
using Views;

namespace Setup
{
    public class EnemySetup : Setup<Enemy, EnemyView>
    {
        [SerializeField] private HealthBar _healthBar;

        private IHealth _healthGolem;
        private HealthPresenter _healthPresenter;

        private void Awake()
        {
            enabled = false;
        }

        public void Init(Score score, params ITarget[] targets)
        {
            Model = new Golem(targets, View.transform.position);
            Presenter = new EnemyPresenter(Model, View, score);

            _healthGolem = Model.Health;
            _healthPresenter = new HealthPresenter(_healthBar, _healthGolem);
            _healthBar.SetStartValueOfSlider();

            if (Model is IUpdateable updateable)
                Updateable = updateable;

            enabled = true;
        }

        private void OnEnable()
        {
            Presenter.Enable();
            _healthPresenter.Enable();
        }

        private void Update()
        {
            Updateable?.Update(Time.deltaTime);
        }

        private void OnDisable()
        {
            Presenter.Disable();
            _healthPresenter.Disable();
        }
    }
}
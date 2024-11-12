using Model;
using Presenters;
using UnityEngine;
using Views;

namespace Setup
{
    public class ArcherSetup : Setup<Archer, ArcherView>
    {
        [SerializeField] private Root _root;
        [SerializeField] private HealthBar _healthBar;

        private IHealth _healthArcher;
        private HealthPresenter _healthPresenter;

        private void Awake()
        {
            _root.Init();
        }

        private void OnEnable()
        {
            Model = _root.Archer;
            Presenter = new HeroPresenter(Model, View);

            _healthArcher = Model.Health;
            _healthPresenter = new HealthPresenter(_healthBar, _healthArcher);

            Presenter.Enable();
            _healthPresenter.Enable();
        }

        private void OnDisable()
        {
            Presenter.Disable();
            _healthPresenter.Disable();
        }
    }
}
using Model;
using Presenters;
using UnityEngine;
using Views;

namespace Setup
{
    public class CastleSetup : Setup<Castle, CastleView>
    {
        [SerializeField] private Root _root;
        [SerializeField] private HealthBar _healthBar;

        private IHealth _healthCastle;
        private HealthPresenter _healthPresenter;

        private void Awake()
        {
            _root.Init();
        }

        private void OnEnable()
        {
            Model = _root.Castle;
            Presenter = new CastlePresenter(Model, View);

            _healthCastle = Model.Health;
            _healthPresenter = new HealthPresenter(_healthBar, _healthCastle);

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
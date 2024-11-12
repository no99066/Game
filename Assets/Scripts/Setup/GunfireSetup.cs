using Model;
using Model.Weapon;
using Presenters;
using UnityEngine;
using Views;

namespace Setup
{
    public class GunfireSetup : Setup<Gunfire, GunfireView>
    {
        public void Init(EnemyView enemyView, GunfireView gunfireView)
        {
            Model = new Gunfire(gunfireView.Position, enemyView.Position);
            Presenter = new GunfirePresenter(Model, View);

            if (Model is IUpdateable updateable)
                Updateable = updateable;

            enabled = true;
        }

        private void OnEnable()
        {
            Presenter.Enable();
        }

        private void Update()
        {
            Updateable?.Update(Time.deltaTime);
        }

        private void OnDisable()
        {
            Presenter.Disable();
        }
    }
}
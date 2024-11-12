using Model.Spells;
using Presenters;
using UnityEngine;

namespace Setup
{
    public class HealthSpellSetup : Setup<HealthSpell, SpellView>
    {
        [SerializeField] private Root _root;

        private void OnEnable()
        {
            _root.Init();
            Model = _root.HealthSpell;
            Presenter = new SpellPresenter(Model, View, _root.GetHeroes());

            Presenter.Enable();
        }

        private void OnDisable()
        {
            Presenter.Disable();
        }
    }
}
using Model.Spells;
using Presenters;
using UnityEngine;

namespace Setup
{
    public class RageSpellSetup : Setup<RageSpell, SpellView>
    {
        [SerializeField] private Root _root;

        private void OnEnable()
        {
            _root.Init();
            Model = _root.RageSpell;
            Presenter = new SpellPresenter(Model, View, _root.GetHeroes());

            Presenter.Enable();
        }

        private void OnDisable()
        {
            Presenter.Disable();
        }
    }
}
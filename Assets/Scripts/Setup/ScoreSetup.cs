using Model.Score;
using Presenters;
using UnityEngine;
using Views;

namespace Setup
{
    public class ScoreSetup : Setup<Score, ScoreView>
    {
        [SerializeField] private Root _root;

        private void OnEnable()
        {
            _root.Init();
            Model = _root.Score;
            Presenter = new ScorePresenter(Model, View);

            Presenter.Enable();
        }

        private void OnDisable()
        {
            Presenter.Disable();
        }
    }
}
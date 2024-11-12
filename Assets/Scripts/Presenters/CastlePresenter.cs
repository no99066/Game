using Model;
using Views;

namespace Presenters
{
    public class CastlePresenter : IPresenter
    {
        private readonly Castle _castle;
        private readonly CastleView _castleView;

        public CastlePresenter(Castle castle, CastleView castleView)
        {
            _castle = castle;
            _castleView = castleView;
        }

        public void Enable()
        {
            _castle.Health.Died += OnModelDied;
            _castle.TookDamage += OnTookDamage;
        }

        public void Disable()
        {
            _castle.Health.Died -= OnModelDied;
            _castle.TookDamage -= OnTookDamage;
        }

        private void OnModelDied()
        {
            _castleView.Died();
        }

        private void OnTookDamage()
        {
            _castleView.Attack();
        }
    }
}
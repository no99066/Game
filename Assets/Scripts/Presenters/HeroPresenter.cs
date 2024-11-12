using Model;
using Views;

namespace Presenters
{
    public class HeroPresenter : IPresenter
    {
        private readonly Hero _hero;
        private readonly HeroView _heroView;

        public HeroPresenter(Hero hero, HeroView heroView)
        {
            _hero = hero;
            _heroView = heroView;
        }

        public void Enable()
        {
            _hero.Health.Died += OnModelDied;
            _hero.RestoredHealth += OnRestoredHealth;
            _hero.Raged += OnRaged;

            _heroView.Relieved += OnViewRelieved;
        }

        public void Disable()
        {
            _hero.Health.Died -= OnModelDied;
            _hero.RestoredHealth -= OnRestoredHealth;
            _hero.Raged -= OnRaged;

            _heroView.Relieved += OnViewRelieved;
        }

        private void OnModelDied()
        {
            _heroView.Died();
        }

        private void OnRaged(float speedUp)
        {
            _heroView.Rage(speedUp);
        }

        private void OnRestoredHealth()
        {
            _heroView.RestoreHealth();
        }

        private void OnViewRelieved()
        {
            _hero.Relieve();
        }
    }
}
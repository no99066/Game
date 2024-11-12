using Model;

namespace Presenters
{
    public class HealthPresenter : IPresenter
    {
        private readonly HealthBar _healthView;
        private readonly IHealth _healthModel;

        public HealthPresenter(HealthBar healthView, IHealth healthModel)
        {
            _healthView = healthView;
            _healthModel = healthModel;
        }

        public void Enable()
        {
            _healthModel.Died += OnDied;
            _healthModel.HealthChanged += OnHealthChanged;
            _healthModel.Relieved += OnRelieved;
        }

        public void Disable()
        {
            _healthModel.Died -= OnDied;
            _healthModel.HealthChanged -= OnHealthChanged;
            _healthModel.Relieved -= OnRelieved;
        }

        private void OnHealthChanged(float currentHealth, float maxHealth) =>
            _healthView.OnValueChanged(currentHealth, maxHealth);

        private void OnRelieved()
        {
            _healthView.SetStartValueOfSlider();
            _healthView.OnRelieved();
        }

        private void OnDied()
        {
            _healthView.OnDied();
        }
    }
}
using System.Collections.Generic;
using Model;
using Model.Score;
using Model.Spells;
using Spawner;
using UnityEngine;
using UnityEngine.SceneManagement;
using Views;
using Views.Window;

public class Root : MonoBehaviour
{
    [SerializeField] private WizardView _wizardView;
    [SerializeField] private ArcherView _archerView;
    [SerializeField] private CastleView _castleView;
    [SerializeField] private GameOverWindow _gameOverWindow;
    [SerializeField] private Wave[] _waves;

    private bool _isInit;

    public Wizard Wizard { get; private set; }
    public Archer Archer { get; private set; }
    public Castle Castle { get; private set; }
    public HealthSpell HealthSpell { get; private set; }
    public RageSpell RageSpell { get; private set; }
    public Score Score { get; private set; }
    public Wave[] Waves => _waves;

    public void Init()
    {
        if (_isInit)
            return;

        Wizard = new Wizard(_wizardView.Position);
        Archer = new Archer(_archerView.Position);

        Castle = new Castle(_castleView.Position);

        HealthSpell = new HealthSpell();
        RageSpell = new RageSpell();

        Score = new Score();

        _isInit = true;
    }

    private void OnEnable()
    {
        Castle.Health.Died += OnCastleDestroyed;
    }

    private void OnDisable()
    {
        Castle.Health.Died -= OnCastleDestroyed;
    }

    private void OnCastleDestroyed()
    {
        StopGame();
        _gameOverWindow.Show(Score.Value, () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }

    public IEnumerable<Hero> GetHeroes()
    {
        return new Hero[] {Wizard, Archer};
    }
}
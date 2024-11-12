using Model.Score;
using Views;

namespace Presenters
{
    public class ScorePresenter : IPresenter
    {
        private readonly Score _score;
        private readonly ScoreView _scoreView;

        public ScorePresenter(Score score, ScoreView scoreView)
        {
            _score = score;
            _scoreView = scoreView;
        }

        public void Enable()
        {
            _score.ScoreChanged += OnScoreChanged;
        }

        public void Disable()
        {
            _score.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int score)
        {
            _scoreView.ScoreChange(score);
        }
    }
}
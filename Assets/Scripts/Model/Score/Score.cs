using System;

namespace Model.Score
{
    public class Score : Entity
    {
        public int Value { get; private set; }

        public event Action<int> ScoreChanged;

        public void OnEnemyDied()
        {
            Value += Config.GolemScore;
            ScoreChanged?.Invoke(Value);
        }
    }
}
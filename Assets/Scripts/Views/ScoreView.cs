using TMPro;
using UnityEngine;

namespace Views
{
    public class ScoreView : View
    {
        [SerializeField] private TMP_Text _text;

        public void ScoreChange(int score)
        {
            _text.text = $"Score: {score}";
        }
    }
}
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Window
{
    public class GameOverWindow : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private TMP_Text _scoreLabel;

        private const string MessageOfGameOver = "Game Over\nYOUR SCORE: ";

        public void Show(int score, Action onReloadClick)
        {
            _scoreLabel.text = $"{MessageOfGameOver} {score}";

            _restartButton.onClick.RemoveAllListeners();
            _restartButton.onClick.AddListener(() => onReloadClick());

            gameObject.SetActive(true);
        }
    }
}
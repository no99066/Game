using UnityEngine;
using UnityEngine.UI;
using Views.Window;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private PauseWindow _pauseWindow;

    private bool _isPaused;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseClick);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseClick);
    }

    private void OnPauseClick()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            _pauseWindow.Show();
            Time.timeScale = 0;
        }
        else
        {
            _pauseWindow.Hide();
            Time.timeScale = 1;
        }
    }
}
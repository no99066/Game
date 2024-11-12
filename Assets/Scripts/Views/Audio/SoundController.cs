using UnityEngine;
using UnityEngine.UI;

namespace Views.Audio
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Animator))]
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private readonly int _isMusicPlay = Animator.StringToHash("IsMusicPlay");
        private Button _musicControlButton;
        private Animator _animator;
        private bool _isMusicOn = true;

        private void Awake()
        {
            _musicControlButton = GetComponent<Button>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _musicControlButton.onClick.AddListener(OnMusicButtonClick);
        }

        private void OnDisable()
        {
            _musicControlButton.onClick.RemoveListener(OnMusicButtonClick);
        }

        private void OnMusicButtonClick()
        {
            _isMusicOn = !_isMusicOn;
            _animator.SetBool(_isMusicPlay, _isMusicOn);
            _audioSource.enabled = _isMusicOn;
        }
    }
}
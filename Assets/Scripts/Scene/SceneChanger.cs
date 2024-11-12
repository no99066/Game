using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scene
{
    [RequireComponent(typeof(Button))]
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingPanel;
        [SerializeField] private Image _slider;
        [SerializeField] private int _indexOfSceneForLoad;
        [SerializeField] private float _speedOfLoading;

        private Button _changeSceneButton;

        private void Awake()
        {
            _changeSceneButton = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _changeSceneButton.onClick.AddListener(OnStartButtonClick);
        }

        private void OnDisable()
        {
            _changeSceneButton.onClick.AddListener(OnStartButtonClick);
        }

        private void OnStartButtonClick()
        {
            StartCoroutine(LoadingScene(_indexOfSceneForLoad));
        }

        private IEnumerator LoadingScene(int sceneId)
        {
            var operation = SceneManager.LoadSceneAsync(sceneId);
            
            _loadingPanel.SetActive(true);
            while (operation.isDone == false)
            {
                var progressValue = Mathf.Clamp01(operation.progress / _speedOfLoading);

                _slider.fillAmount = progressValue;
                yield return null;
            }
        }
    }
}
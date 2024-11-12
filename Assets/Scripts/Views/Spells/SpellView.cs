using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Views;

public class SpellView : View
{
    [SerializeField] private Image _reloadImage;
    [SerializeField] private Button _spellButton;
    [SerializeField] private float _cooldownDuration;

    public void Add(UnityAction action)
    {
        _spellButton.onClick.AddListener(OnHeelButtonClick);
        _spellButton.onClick.AddListener(action);
    }

    public void Remove(UnityAction action)
    {
        _spellButton.onClick.RemoveListener(OnHeelButtonClick);
        _spellButton.onClick.RemoveListener(action);
    }

    private void OnHeelButtonClick()
    {
        StartCoroutine(HeelReloading(_cooldownDuration));
    }

    private IEnumerator HeelReloading(float duration)
    {
        _reloadImage.fillAmount = 0;
        float elapsedTime = 0;

        StartCoroutine(WaitingToFill());

        while (elapsedTime < duration)
        {
            yield return null;
            var nextValue = Mathf.Lerp(0, 1, elapsedTime / duration);
            _reloadImage.fillAmount = nextValue;
            elapsedTime += Time.deltaTime;
        }

        _reloadImage.fillAmount = 1;
    }

    private IEnumerator WaitingToFill()
    {
        _spellButton.interactable = false;
        yield return new WaitUntil(() => (int) _reloadImage.fillAmount == 1);
        _spellButton.interactable = true;
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ShootButton))]
public class CooldownGunfire : MonoBehaviour
{
    [SerializeField] private Image _reloadImage;
    [SerializeField] private ShootButton _shootButton;

    private void OnEnable()
    {
        _shootButton.Add(OnShootButtonClick);
    }

    private void OnDisable()
    {
        _shootButton.Remove(OnShootButtonClick);
    }

    private void OnShootButtonClick()
    {
        StartCoroutine(GunfireReloading(_shootButton.CooldownDuration));
    }

    private IEnumerator GunfireReloading(float duration)
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
        _shootButton.TurnOff();
        yield return new WaitUntil(() => (int) _reloadImage.fillAmount == 1);
        _shootButton.TurnOn();
    }
}
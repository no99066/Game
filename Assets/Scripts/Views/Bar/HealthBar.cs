using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Bar
{
    [SerializeField] private Image _colorOfHealthBar;
    [SerializeField] private Color _lowColor;
    [SerializeField] private Color _highColor;

    private const float StartValueOfSlider = 1;

    public override void SetStartValueOfSlider()
    {
        Slider.value = StartValueOfSlider;
        _colorOfHealthBar.color = _highColor;
    }

    protected override void ChangeColor()
    {
        _colorOfHealthBar.color = Color.Lerp(_lowColor, _highColor, Slider.normalizedValue);
    }

    public void OnDied()
    {
        enabled = false;
    }

    public void OnRelieved()
    {
        enabled = true;
    }
}
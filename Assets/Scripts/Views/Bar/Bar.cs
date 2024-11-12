using UnityEngine;
using UnityEngine.UI;
using Views;

public abstract class Bar : View
{
    [SerializeField] protected Slider Slider;

    protected abstract void ChangeColor();
    public abstract void SetStartValueOfSlider();

    public void OnValueChanged(float minValue, float maxValue)
    {
        Slider.value = minValue / maxValue;
        ChangeColor();
    }

    public override void Died()
    {
    }
}
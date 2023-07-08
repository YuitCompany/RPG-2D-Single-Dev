using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBarUI : MonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] IHealthBar _object;

    [Space]
    [SerializeField] Slider _slider_bar;
    [SerializeField] Image _fill_bar;
    [SerializeField] Gradient _color_bar;
    [SerializeField] Text _text_bar;

    [Header("Health Status")]
    [SerializeField] int _health;
    [SerializeField] int _health_max;

    private void Awake()
    {
        _object = GetComponentInParent<IHealthBar>();
        _slider_bar = GetComponentInParent<Slider>();
        _fill_bar = GetComponentInChildren<Image>();
        _text_bar = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        Set_StartHealth();
    }

    private void Update()
    {
        Set_CurrentHealth();
    }

    public void Set_CurrentHealth()
    {
        _slider_bar.value = _object.GetHealth();
        _slider_bar.maxValue = _health_max;
        _fill_bar.color = _color_bar.Evaluate(_slider_bar.normalizedValue);
        _text_bar.text = $"{Mathf.Round(_slider_bar.value / _slider_bar.maxValue * 100)}%";
    }

    public void Set_StartHealth()
    {
        _slider_bar.maxValue = _health_max;
        _slider_bar.minValue = 0f;
        _slider_bar.value = _health;
    }
}

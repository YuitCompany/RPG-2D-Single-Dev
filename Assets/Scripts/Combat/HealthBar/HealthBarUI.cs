using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] Slider _slider_bar;
    [SerializeField] Image _fill_bar;
    [SerializeField] Gradient _color_bar;
    [SerializeField] Text _text_bar;
    [SerializeField] SpawmPosition _spawm_pos;
    [SerializeField] GameObject _text_prefabs;

    IHealthBar _object;
    GameObject _text_object;
    float _health_previous;

    private void Awake()
    {
        _object = GetComponentInParent<IHealthBar>();
        _slider_bar = GetComponentInParent<Slider>();
        _fill_bar = GetComponentInChildren<Image>();
        _text_bar = GetComponentInChildren<Text>();
        _spawm_pos = GetComponentInChildren<SpawmPosition>();
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
        if(_slider_bar.value != _object.Get_HealthPoint()) _health_previous = _slider_bar.value;
        _slider_bar.value = _object.Get_HealthPoint();
        _slider_bar.maxValue = _object.Get_HealthPointMax();
        _fill_bar.color = _color_bar.Evaluate(_slider_bar.normalizedValue);
        _text_bar.text = $"{Mathf.Round(_slider_bar.value / _slider_bar.maxValue * 100)}%";
    }

    public void Set_StartHealth()
    {
        _slider_bar.maxValue = _object.Get_HealthPointMax();
        _slider_bar.minValue = 0f;
        _slider_bar.value = _object.Get_HealthPoint();
        _health_previous = _object.Get_HealthPoint();
    }

    public void OnChangeHealthEvent()
    {
        _text_object = Instantiate(_text_prefabs, _spawm_pos.transform.position, Quaternion.identity, _spawm_pos.transform);
        _text_object.transform.SetParent(_spawm_pos.transform);
        _text_object.GetComponent<Text>().text = (Mathf.Abs(_health_previous - _object.Get_HealthPoint())).ToString();
        
        if (_health_previous >= _slider_bar.value) _text_object.GetComponent<Text>().color = Color.red;
        else _text_object.GetComponent<Text>().color = Color.green;

        _health_previous = _slider_bar.value;
    }
}

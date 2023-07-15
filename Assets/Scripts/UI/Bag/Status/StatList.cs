using Property;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatList : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] StatDisplay[] _list_stat_display;
    [SerializeField] string[] _list_name;
    [SerializeField] EProperty[] _list_value;

    private void OnValidate()
    {
        _list_stat_display = GetComponentsInChildren<StatDisplay>();
        Update_StatName();
    }

    public void Update_StatValue(int i = 0)
    {
        if (i >= _list_value.Length) return;

        _list_stat_display[i].ValueText.text = Character.Instance.Get_CurrentProperty(_list_value[i]).ToString();
        Update_StatValue(i + 1);
    }

    public void Update_StatName(int i = 0)
    {
        if (i >= _list_name.Length) return;

        _list_stat_display[i].NameText.text = _list_name[i].ToString();
        Update_StatName(i + 1);
    }
}

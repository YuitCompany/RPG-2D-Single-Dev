using Property;
using Status;
using System.Collections.Generic;
using UnityEngine;

public class Character : Singleton<Character>, IHealthBar
{
    [Header("Player Info")]
    [SerializeField] string _name;
    [SerializeField] string _description;

    [Header("Player Status")]
    [SerializeField] List<EProperty> _list_key = new List<EProperty>();
    [SerializeField] List<float> _list_value = new List<float>();

    Status.Status _status;

    protected override void Awake()
    {
        base.Awake();

        _status = new Status.Status();
    }

    private void Update()
    {
        Set_Status(_list_key, _list_value);
    }

    private void Set_Status(List<EProperty> lkey, List<float> lvalue, int i = 0)
    {
        if (i >= lkey.Count) return;
        _status.Set_Property(lkey[i], lvalue[i]);
        Set_Status(lkey, lvalue, i + 1);
    }

    public float Get_Property(EProperty k)
    {
        if (!_status.Is_Property(k)) return 0;
        return _status.Get_Property(k);
    }
    private void Change_Property(EProperty k, float v, EOperator o)
    {
        if (!_status.Is_Property(k)) return;

        _status.Change_Property(new FloatProperty(k, v), o);
    }

    // IHealthBar
    public float Get_HealthPoint()
    {
        return Get_Property(EProperty.Health_Point);
    }
    public float Get_HealthPointMax()
    {
        return Get_Property(EProperty.Health_Point_Max);
    }    

    public void Set_TakeDamage(float value)
    {
        Change_Property(EProperty.Health_Point, value, EOperator.Minus);
    }
    public void Set_TakeHeal(float value)
    {
        Change_Property(EProperty.Health_Point, value, EOperator.Plus);
    }    
}

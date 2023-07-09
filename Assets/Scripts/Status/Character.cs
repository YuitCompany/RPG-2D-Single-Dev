using Property;
using Status;
using System.Collections.Generic;
using UnityEngine;

public enum EWeaponSlot
{
    main, support
}

public class Character : Singleton<Character>, IHealthBar
{
    [Header("Player Info")]
    [SerializeField] string _name;
    [SerializeField] string _description;

    [Header("Player Status")]
    [SerializeField] List<EProperty> _list_key = new List<EProperty>();
    [SerializeField] List<float> _list_value = new List<float>();

    [Header("Equipment")]
    [SerializeField] Dictionary<EWeaponSlot, Status.Status> _dic_weapon = new Dictionary<EWeaponSlot, Status.Status>();
    [SerializeField] List<Status.Status> _list_item = new List<Status.Status>();

    Status.Status _status;

    protected override void Awake()
    {
        base.Awake();

        _status = new Status.Status();
        Set_Status(_list_key, _list_value);
    }

    private void Update()
    {
        Debug.Log(_status.Get_Property(EProperty.Health_Point));
        Debug.Log(_status.Get_Property(EProperty.Attack_Power));
        Debug.Log(_status.Get_Property(EProperty.Attack_Speed));
        Debug.Log(_status.Get_Property(EProperty.Move_Speed));
    }

    private void Set_Status(List<EProperty> lkey, List<float> lvalue)
    {
        _status.Set_PropertyList(lkey, lvalue);
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

    public void Set_TakeDamage(float v)
    {
        Change_Property(EProperty.Health_Point, v, EOperator.Minus);
    }
    public void Set_TakeHeal(float v)
    {
        Change_Property(EProperty.Health_Point, v, EOperator.Plus);
    }

    // Equip Item
    public void Equip_Weapon(EWeaponSlot k, Status.Status s)
    {
        if (!_dic_weapon.ContainsKey(k)) _dic_weapon.Add(k, s);
        else if (_dic_weapon[k].Is_Equal(s)) return;
        else
        {
            Unequip_Weapon(k); 
            _dic_weapon.Add(k, s);
        }

        _status.Change_Property(s, EOperator.Plus);
    }
    public void Unequip_Weapon(EWeaponSlot k)
    {
        _status.Change_Property(_dic_weapon[k], EOperator.Minus);
        _dic_weapon.Remove(k);
    }

    public void Equip_Item(Status.Status s)
    {
        if(_list_item.Contains(s)) return;
        _status.Change_Property(s, EOperator.Plus);
        _list_item.Add(s);
    }
    public void Unequip_Item(Status.Status s)
    {
        if(!_list_item.Contains(s)) return;
        _status.Change_Property(s, EOperator.Minus);
        _list_item.Remove(s);
    }
}

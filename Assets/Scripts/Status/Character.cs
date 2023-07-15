using Property;
using Status;
using System.Collections;
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
    [SerializeField] List<EProperty> listKey = new List<EProperty>();
    [SerializeField] List<float> listValue = new List<float>();

    [Header("Equipment")]
    [SerializeField] Dictionary<EInventoryType, Status.Status> _dict_euqipment_item = new Dictionary<EInventoryType, Status.Status>();

    Status.Status _base_status, _equipment_status, _current_status;

    protected override void Awake()
    {
        base.Awake();

        _base_status = new Status.Status();
        _equipment_status = new Status.Status();
        _current_status = new Status.Status();
        Set_Status(listKey, listValue);
    }

    //private void Update()
    //{
    //    Debug.Log("HP: " + CurrentStatus.Get_Property(EProperty.Health_Point));
    //    Debug.Log("Max HP: " + CurrentStatus.Get_Property(EProperty.Health_Point_Max));
    //    Debug.Log("Max MP: " + CurrentStatus.Get_Property(EProperty.Mana_Point_Max));
    //    Debug.Log("ATK: " + CurrentStatus.Get_Property(EProperty.Attack_Power));
    //    Debug.Log("ATK SPD: " + CurrentStatus.Get_Property(EProperty.Attack_Speed));
    //    Debug.Log("DEF: " + CurrentStatus.Get_Property(EProperty.Defense_Amount));
    //    Debug.Log("Move SPD: " + CurrentStatus.Get_Property(EProperty.Move_Speed));
    //}

    // Get/Set
    public Status.Status BaseStatus { get { return _base_status; } private set { _base_status = value; } }
    public Status.Status CurrentStatus { get { return _current_status; } private set { _current_status = value; } }
    public Status.Status EquipmentStatus { get { return _equipment_status; } private set { _equipment_status = value; } }

    // base Status
    private void Set_Status(List<EProperty> lkey, List<float> lvalue)
    {
        BaseStatus.Set_PropertyList(lkey, lvalue);
        CurrentStatus.Set_PropertyList(lkey, lvalue);
    }
    public float Get_BaseProperty(EProperty k)
    {
        if (!BaseStatus.Is_Property(k)) return 0;
        return CurrentStatus.Get_Property(k);
    }
    private void Change_BaseProperty(EProperty k, float v, EOperator o)
    {
        if (!BaseStatus.Is_Property(k)) return;

        BaseStatus.Change_Property(new FloatProperty(k, v), o);
    }

    // current Status
    private void Update_CurrentStatus(Status.Status s, EOperator o)
    {
        CurrentStatus.Change_Property(s, o);
    }
    private void Change_CurrentProperty(EProperty k, float v, EOperator o)
    {
        if (!CurrentStatus.Is_Property(k)) return;

        CurrentStatus.Change_Property(new FloatProperty(k, v), o);
    }
    public float Get_CurrentProperty(EProperty k)
    {
        return CurrentStatus.Get_Property(k);
    }

    // IHealthBar
    public float Get_HealthPoint()
    {
        return Get_CurrentProperty(EProperty.Health_Point);
    }
    public float Get_HealthPointMax()
    {
        return Get_CurrentProperty(EProperty.Health_Point_Max);
    }    

    public void Set_TakeDamage(float v)
    {
        Change_CurrentProperty(EProperty.Health_Point, v, EOperator.Minus);
    }
    public void Set_TakeHeal(float v)
    {
        Change_CurrentProperty(EProperty.Health_Point, v, EOperator.Plus);
    }

    // Equip Item
    public void Equip_Item(EInventoryType k, Status.Status s)
    {
        if(_dict_euqipment_item.ContainsKey(k)) return;

        _equipment_status.Change_Property(s, EOperator.Plus);
        Update_CurrentStatus(s, EOperator.Plus);
        _dict_euqipment_item.Add(k, s);
    }
    public void Unequip_Item(EInventoryType k, Status.Status s)
    {
        if(!_dict_euqipment_item.ContainsKey(k)) return;

        EquipmentStatus.Change_Property(s, EOperator.Minus);
        Update_CurrentStatus(s, EOperator.Minus);
        _dict_euqipment_item.Remove(k);
    }
}

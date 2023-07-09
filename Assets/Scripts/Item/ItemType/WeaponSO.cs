using Property;
using System.Collections.Generic;
using UnityEngine;

public enum EWeaponType
{
    Blade, Bow
}

public class WeaponSO : ItemSO
{
    public EWeaponType weaponType;
    
    [Space]
    [Header("Base Status")]
    [SerializeField] List<EProperty> _list_type = new List<EProperty>();
    [SerializeField] List<float> _list_value = new List<float>();

    Status.Status _weapon_status = new Status.Status();

    public void OnValidate()
    {
        _weapon_status.Set_PropertyList(_list_type, _list_value);
    }

    public override void Update()
    {
        base.Update();

        this.itemType = EItemType.Weapon;
    }

    public Status.Status Get_Status()
    {
        return _weapon_status;
    }
}

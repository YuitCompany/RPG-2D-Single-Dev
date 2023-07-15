using Property;
using System.Collections.Generic;
using UnityEngine;

public enum EWeaponType
{
    Blade, Bow
}

public class WeaponSO : EquipmentSO
{
    public EWeaponType weaponType;
    
    [Space]
    [Header("Base Status")]
    [SerializeField] List<EProperty> listKey = new List<EProperty>();
    [SerializeField] List<float> listValue = new List<float>();
    
    Status.Status _weapon_status = new Status.Status();

    public void OnValidate()
    {
        _weapon_status.Set_PropertyList(listKey, listValue);
    }

    public override void Update()
    {
        base.Update();

        this.equipmentType = EEquipmentType.Weapon;
    }

    public Status.Status Get_Status()
    {
        return _weapon_status;
    }

    public override EInventoryType Get_InventoryType()
    {
        return base.Get_InventoryType();
    }
}

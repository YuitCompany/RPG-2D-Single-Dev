using Property;
using System.Collections.Generic;
using UnityEngine;

public enum EInventoryType
{
    None, Helmet, Armor, Pant, Boot, Necklace, Ring
}

public class InventorySO : EquipmentSO
{
    public EInventoryType inventoryType;

    [Space]
    [Header("Base Status")]
    [SerializeField] List<EProperty> listKey = new List<EProperty>();
    [SerializeField] List<float> listValue = new List<float>();

    Status.Status _inventory_status = new Status.Status();

    private void OnValidate()
    {
        _inventory_status.Set_PropertyList(listKey, listValue);
    }

    public override void Update()
    {
        base.Update();

        this.equipmentType = EEquipmentType.Inventory;
    }

    public override Status.Status Get_Status()
    {
        return _inventory_status;
    }

    public override EInventoryType Get_InventoryType()
    {
        return inventoryType;
    }
}

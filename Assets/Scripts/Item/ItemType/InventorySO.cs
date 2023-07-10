using Property;
using System.Collections.Generic;
using UnityEngine;

public enum EInventoryType
{
    Helmet, Armor, Pant, Boot, Necklace
}

public class InventorySO : ItemSO
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

        this.itemType = EItemType.Inventory;
    }

    public Status.Status GetStatus()
    {
        return _inventory_status;
    }
}

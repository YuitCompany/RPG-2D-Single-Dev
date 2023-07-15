using UnityEngine;

public enum EEquipmentType
{
    Item, Inventory, Weapon
}

public class EquipmentSO : ItemSO
{
    public EEquipmentType equipmentType;

    public override void Update()
    {
        base.Update();

        this.itemType = EItemType.Equipment;
    }

    public virtual EInventoryType Get_InventoryType()
    {
        return EInventoryType.None;
    }
}

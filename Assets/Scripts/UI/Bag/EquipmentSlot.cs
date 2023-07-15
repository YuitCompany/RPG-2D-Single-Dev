
public class EquipmentSlot : ItemSlot
{
    public EEquipmentType equipmentType;
    public EInventoryType inventoryType;

    protected override void OnValidate()
    {
        base.OnValidate();

        Item = null;

        if (equipmentType == EEquipmentType.Inventory)
        {
            this.gameObject.name = inventoryType.ToString() + " " + equipmentType.ToString() + " Slot";
        }
        else this.gameObject.name = equipmentType.ToString() + " Slot";
    }
}

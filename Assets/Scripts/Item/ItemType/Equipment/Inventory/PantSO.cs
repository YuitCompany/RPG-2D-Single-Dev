using UnityEngine;

[CreateAssetMenu(fileName = "New Pant", menuName = "GameData/Item/Inventory/Pant")]
public class PantSO : InventorySO
{
    [Space]
    [Header("Sprite")]
    [SerializeField] Sprite pant;

    public override void Update()
    {
        base.Update();

        this.inventoryType = EInventoryType.Pant;
        this.description = "Self-Protection Pant";

        this.Set_ItemSprite(pant);
    }
}

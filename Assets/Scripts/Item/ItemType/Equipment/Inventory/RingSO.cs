using UnityEngine;

[CreateAssetMenu(fileName = "New Ring", menuName = "GameData/Item/Inventory/Ring")]
public class RingSO : InventorySO
{
    [Space]
    [Header("Sprite")]
    [SerializeField] Sprite ring;

    public override void Update()
    {
        base.Update();

        this.inventoryType = EInventoryType.Ring;
        this.description = "Magical Ring";

        this.Set_ItemSprite(ring);
    }
}
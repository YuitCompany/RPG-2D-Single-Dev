using UnityEngine;

[CreateAssetMenu(fileName = "New Helmet", menuName = "GameData/Item/Inventory/Helmet")]
public class HelmetSO : InventorySO
{
    [Space]
    [Header("Sprite")]
    [SerializeField] Sprite helmet;

    public override void Update()
    {
        base.Update();

        this.inventoryType = EInventoryType.Helmet;
        this.description = "Self-Protection Helmet";

        this.Set_ItemSprite(helmet);
    }
}

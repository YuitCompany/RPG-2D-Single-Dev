using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mew Boot", menuName = "GameData/Item/Inventory/Boot")]
public class BootSO : InventorySO
{
    [Space]
    [Header("Sprite")]
    [SerializeField] Sprite boot;

    public override void Update()
    {
        base.Update();

        this.inventoryType = EInventoryType.Boot;
        this.description = "Flexible Boot";

        this.Set_ItemSprite(boot);
    }
}

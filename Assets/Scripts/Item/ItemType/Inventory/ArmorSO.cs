using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "GameData/Item/Inventory/Armor")]
public class ArmorSO : InventorySO
{
    [Space]
    [Header("Sprite")]
    [SerializeField] Sprite armor;

    public override void Update()
    {
        base.Update();

        this.inventoryType = EInventoryType.Armor;
        this.description = "Self-Protection Armor";

        this.Set_ItemSprite(armor);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Necklace", menuName = "GameData/Item/Inventory/Necklace")]
public class NecklaceSO : InventorySO
{
    [Space]
    [Header("Sprite")]
    [SerializeField] Sprite necklace;

    public override void Update()
    {
        base.Update();

        this.inventoryType = EInventoryType.Necklace;
        this.description = "A Necklace Of Blessings";

        this.Set_ItemSprite(necklace);
    }
}

using Property;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bow", menuName = "GameData/Item/Weapon/Bow")]
public class BowSO : WeaponSO
{
    [Space]
    [Header("Sprite")]
    [SerializeField] Sprite Bow;

    public override void Update()
    {
        base.Update();

        this.weaponType = EWeaponType.Blade;
        this.description = "A Normal Bow";

        this.Set_ItemSprite(Bow);
    }
}
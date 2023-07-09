using Property;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Blade", menuName = "GameData/Item/Weapon/Blade")]
public class BladeSO : WeaponSO
{
    [Header("Base Status")]
    [SerializeField] List<EProperty> _list_type = new List<EProperty>();
    [SerializeField] List<float> _list_value = new List<float>();

    [Space]
    [Header("Sprite")]
    [SerializeField] Sprite spriteBlade;

    public override void Update()
    {
        base.Update();

        this.weaponType = EWeaponType.Blade;
        this.description = "A Blade Of Hero";

        this.Set_ItemSprite(spriteBlade);
    }
}

public enum EWeaponType
{
    Blade, Bow
}

public class WeaponSO : ItemSO
{
    public EWeaponType weaponType;

    public override void Update()
    {
        base.Update();

        this.itemType = EItemType.Weapon;
    }
}

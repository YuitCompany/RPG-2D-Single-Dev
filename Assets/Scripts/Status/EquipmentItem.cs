using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipmentItem : MonoBehaviour
{
    [Header("Connect Script")]
    public ActiveWeapon weapon;

    [Header("Equip Weapon")]
    [SerializeField] WeaponSO _m_weaponSO;
    [SerializeField] WeaponSO _s_weaponSO;

    private void Awake()
    {
        weapon = GetComponentInChildren<ActiveWeapon>();
    }

    private void Update()
    {
        if (_m_weaponSO != null)
        {
            Character.Instance.Equip_Weapon(EWeaponSlot.main, _m_weaponSO.Get_Status());
            CharacterEquipment(weapon.m_weapon, _m_weaponSO.Get_ItemSprite());
        }

        if (_s_weaponSO != null)
        {
            Character.Instance.Equip_Weapon(EWeaponSlot.support, _s_weaponSO.Get_Status());
            CharacterEquipment(weapon.s_weapon, _s_weaponSO.Get_ItemSprite());
        }
    }

    private void CharacterEquipment(GameObject slot, Sprite equip)
    {
        slot.GetComponent<SpriteRenderer>().sprite = equip;
    }
}

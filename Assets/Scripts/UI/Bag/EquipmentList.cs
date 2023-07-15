using System;
using UnityEngine;

public class EquipmentList : MonoBehaviour
{
    [SerializeField] Transform equipSlotParent;
    [SerializeField] EquipmentSlot[] listEquipSlot;

    public event Action<ItemSO> OnItemLeftClickEvent;

    private void Awake()
    {
        foreach(EquipmentSlot i in listEquipSlot)
        {
            i.OnLeftClickEvent += OnItemLeftClickEvent;
        }
    }

    private void OnValidate()
    {
        listEquipSlot = equipSlotParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool Add_Item(EquipmentSO item, out EquipmentSO pre_item)
    {
        foreach (EquipmentSlot i in listEquipSlot)
        {
            if (i.equipmentType == item.equipmentType && i.inventoryType == item.Get_InventoryType())
            {
                pre_item = (EquipmentSO)i.Item;
                i.Item = item;
                return true;
            }
        }

        pre_item = null;
        return false;
    }

    public bool Remove_Item(EquipmentSO item)
    {
        foreach (EquipmentSlot i in listEquipSlot)
        {
            if(i.Item == item)
            {
                i.Item = null;
                return true;
            }
        }

        return false;
    }
}

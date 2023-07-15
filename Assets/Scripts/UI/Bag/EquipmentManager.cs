using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [Header("Connect Script")]
    [SerializeField] StatList _show_stat;

    [Header("Item-Available And Item-Equiped")]
    [SerializeField] ItemList _list_item;
    [SerializeField] EquipmentList _list_equipment;

    private void Awake()
    {
        _list_item.OnItemLeftClickEvent += Equip_FromListItem;
        _list_equipment.OnItemLeftClickEvent += Unequip_FromListItem;

        _show_stat.Update_StatValue();
    }

    private void Equip_FromListItem(ItemSO item)
    {
        if (item is EquipmentSO)
        {
            Equip_Item((EquipmentSO)item);
            _show_stat.Update_StatValue();
        }
    }

    private void Unequip_FromListItem(ItemSO item)
    {
        if (item is EquipmentSO)
        {
            Unequip_Item((EquipmentSO)item);
            _show_stat.Update_StatValue();
        }
    }

    public void Equip_Item(EquipmentSO item)
    {
        if(_list_item.Remove_Item(item))
        {
            EquipmentSO pre_item; 

            if (_list_equipment.Add_Item(item, out pre_item))
            {
                Character.Instance.Equip_Item(item.Get_InventoryType(), item.Get_Status());
                if(pre_item != null)
                {
                    Character.Instance.Unequip_Item(pre_item.Get_InventoryType(), pre_item.Get_Status());
                    _list_item.Add_Item(pre_item);
                }
            } else
            {
                _list_item.Add_Item(item);
            }
        }
    }

    public void Unequip_Item(EquipmentSO item)
    {
        if(!_list_item.IsFullList() && _list_equipment.Remove_Item(item))
        {
            Character.Instance.Unequip_Item(item.Get_InventoryType(), item.Get_Status());
            _list_item.Add_Item(item);
        }
    }
}

using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] ItemList _list_item;
    [SerializeField] EquipmentList _list_equipment;

    private void Awake()
    {
        _list_item.OnItemRightClickEvent += Equip_FromListItem;
        _list_equipment.OnItemRightClickEvent += Unequip_FromListItem;
    }

    private void Equip_FromListItem(ItemSO item)
    {
        if (item is EquipmentSO)
        {
            Equip_Item((EquipmentSO)item);
        }
    }

    private void Unequip_FromListItem(ItemSO item)
    {
        if (item is EquipmentSO)
        {
            Unequip_Item((EquipmentSO)item);
        }
    }

    public void Equip_Item(EquipmentSO item)
    {
        if(_list_item.Remove_Item(item))
        {
            EquipmentSO pre_item;

            if(_list_equipment.Add_Item(item, out pre_item))
            {
                if(pre_item != null)
                {
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
            _list_item.Add_Item(item);
        }
    }
}

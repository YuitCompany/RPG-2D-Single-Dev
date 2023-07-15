using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    [SerializeField] List<ItemSO> listItem;
    [SerializeField] Transform listItemParent;
    [SerializeField] ItemSlot[] listItemSlot;

    public event Action<ItemSO> OnItemLeftClickEvent;

    private void Awake()
    {
        foreach (ItemSlot i in listItemSlot)
        {
            i.OnLeftClickEvent += OnItemLeftClickEvent;
        }
    }

    private void OnValidate()
    {
        if(listItemParent != null)
        {
           listItemSlot = listItemParent.GetComponentsInChildren<ItemSlot>();
        }
        RefreshUI();
    }

    private void RefreshUI(int i = 0)
    {
        if (i >= listItemSlot.Length) return;

        if(i >= listItem.Count)
        {
            listItemSlot[i].Item = null;
        } else
        {
            listItemSlot[i].Item = listItem[i];
        }

        RefreshUI(i + 1);
    }

    public bool IsFullList()
    {
        return listItem.Count >= listItemSlot.Length;
    }

    public bool Add_Item(ItemSO item)
    {
        if (IsFullList()) return false;

        listItem.Add(item);

        RefreshUI();
        return true;
    }

    public bool Remove_Item(ItemSO item)
    {
        if (!listItem.Remove(item)) return false;

        RefreshUI();
        return true;
    }

}

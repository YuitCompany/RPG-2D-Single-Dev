using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    [SerializeField] List<ItemSO> listItem;
    [SerializeField] Transform listItemParent;
    [SerializeField] ItemSlot[] listItemSlot;

    private void OnValidate()
    {
        if(listItemParent != null)
        {
           listItemSlot = listItemParent.GetComponentsInChildren<ItemSlot>();
        }
        RefreshUI();
    }

    private void RefreshUI()
    {
        int i = 0;
        for(; i < listItem.Count && i < listItemSlot.Length; i++)
        {
            listItemSlot[i].Item = listItem[i];
        }

        for(; i < listItemSlot.Length; i++)
        {
            listItemSlot[i].Item = null;
        }
    }
}

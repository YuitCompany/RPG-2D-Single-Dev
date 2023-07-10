using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] Image image;

    private ItemSO _item;
    public ItemSO Item 
    { 
        get { return _item; } 
        set { 
            _item = value;

            if (_item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = _item.Get_ItemSprite();
                image.enabled = true;
            }
        } 
    }

    private void OnValidate()
    {
        if(image == null)
        {
            image = GetComponent<Image>();
        }
    }
}

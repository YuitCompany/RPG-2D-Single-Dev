using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image image;

    public event Action<ItemSO> OnLeftClickEvent;

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

    protected virtual void OnValidate()
    {
        if(image == null)
        {
            image = GetComponent<Image>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData == null) return;

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (Item != null && OnLeftClickEvent != null) OnLeftClickEvent(Item);
        }
    }
}

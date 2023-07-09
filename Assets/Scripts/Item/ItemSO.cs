using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EItemType
{
    none, Item, Equipment, Weapon, Quest
}

public class ItemSO : ScriptableObject
{
    public int id;
    public new string name;
    public string description;
    public Sprite icon;
    public EItemType itemType;

    private Sprite itemSprite;
    public Sprite Get_ItemSrpite()
    {
        return this.itemSprite;
    }
    public void Set_ItemSprite(Sprite s)
    {
        this.itemSprite = s;
    }    
    
    public void OnEnable()
    {
        this.Update();
    }

    public virtual void Update()
    {
        //if(this.icon != null)
        //{
        //    this.id = int.Parse(this.icon.name);
        //}
    }
}

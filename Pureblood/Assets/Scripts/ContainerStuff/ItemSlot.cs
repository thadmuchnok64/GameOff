using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public InventorySlot item;
    public int quantity;
    public Items itemO = new Items();
    [SerializeField] Image iconImage;
    [SerializeField] TMPro.TextMeshProUGUI text;
    int ID = 0;

    public void SetItem(InventorySlot i)
    {
        if(i == null)
        {
            iconImage.sprite = null;
            item = null;
            if (text != null)
                text.text = "" + item.item.name + " : " + item.item.description;
        }
        else {
            item = i;
            iconImage.sprite = item.item.sprite;
            if (text != null)
                text.text = "" + item.item.name + " : " + item.item.description;
            //ID = item.GetID();
        }
        
        
    }

    //Needed to make this to display quest item rewards.
    public void SetItem(ItemObject i, int quant)
    {
        if (i == null)
        {
            iconImage.sprite = null;
        }
        else
        {
            item= new InventorySlot(i,quant);
            quantity = quant;
            iconImage.sprite = item.item.sprite;
            if (text != null)
                text.text = "" + item.item.name + " : " + item.item.description;
            //ID = item.GetID();
        }


    }

    public InventorySlot GetItem()
    {
        return item;
    }


    public void SendToInventory()
    {
        InventoryUI.instance.EquipItem(GetItem());
    }

    public int GetID()
    {
        return ID;
    }
    
}

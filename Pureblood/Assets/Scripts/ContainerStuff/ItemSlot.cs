using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    public Items item = new Items();
    [SerializeField] Image iconImage;
    [SerializeField] TMPro.TextMeshProUGUI text;
    int ID = 0;

    public void SetItem(Items i)
    {
        if(i == null)
        {
            iconImage.sprite = null;
        }
        else {
            item = i;
            iconImage.sprite = item.GetIcon();
            if (text != null)
                text.text = "" + item.GetName() + " : " + item.GetDscription();
            ID = item.GetID();
        }
        
        
    }
    public Items GetItem()
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

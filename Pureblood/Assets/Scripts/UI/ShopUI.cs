using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{

    [SerializeField] ItemSlot[] slots;
    [SerializeField] TMPro.TextMeshProUGUI[] costs;
    [SerializeField] TMPro.TextMeshProUGUI name;

    public static ShopUI instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Debug.Log("Multiple shopUI classes. Fix this ya frickin idiot");
            Destroy(this);
        }
        gameObject.SetActive(false);
    }

    public void SetShop(List<InventorySlot> inventory)
    {
        SetShop(inventory, "");
    }

    public void SetShop(List<InventorySlot> inventory,string _name)
    {
        if (_name == "")
        {
            name.text = "";
        }
        else
        {
            name.text = "Bartering with: " + _name;
        }
        int x = 0;
        InventorySlot[] inv = inventory.ToArray();

        for(x = 0; x < slots.Length; x++)
        {

            if (inventory.Count - 1 < x)
            {
                slots[x].gameObject.SetActive(false);
                costs[x].gameObject.SetActive(false);
            }
            else
            {
                slots[x].gameObject.SetActive(true);
                costs[x].gameObject.SetActive(true);
                slots[x].SetItem(inv[x]);
                costs[x].text = "" + inv[x].item.buyValue;
                if (Player.instance.GetPurity() >= inv[x].item.buyValue)
                {
                    slots[x].GetComponent<Button>().interactable = true;
                }
                else
                {
                    slots[x].GetComponent<Button>().interactable = false;
                }
            }
        }

        

    }

    public void Buy(int index)
    {
        Player.instance.AddPurity(-slots[index].item.item.buyValue);
        Player.instance.theInventory.AddItem(slots[index].item.item,1);
    }



}

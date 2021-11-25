using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop", menuName = "Inventory System/Shop")]

public class Shop : InventoryObject
{


    public void SetUpShop(string name)
    {
        UIControls.instance.ShopMenuToggle();
        ShopUI.instance.SetShop(Container,name);
    }

}

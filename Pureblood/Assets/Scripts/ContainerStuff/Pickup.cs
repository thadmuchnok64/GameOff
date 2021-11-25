using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    [SerializeField] int itemId;
    [SerializeField] int quantity;
    // Start is called before the first frame update


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject contactedObject = collision.gameObject;
        if (contactedObject.tag == "Player")
        {
            if (ItemList.instance.GetItem(itemId).GetType().IsSubclassOf(typeof(Consumables)))
            {
                Consumables c = ItemList.instance.GetItem(itemId) as Consumables;
                c.AddQuantity(quantity);
            }
            else if (ItemList.instance.GetItem(itemId).GetType().IsSubclassOf(typeof(Weapons)))
            {
                Weapons c = ItemList.instance.GetItem(itemId) as Weapons;
            }
           // contactedObject.GetComponent<Entity>().GetInventory().AddItem(ItemList.instance.GetItem(itemId));
            Destroy(gameObject);
        }
    }

}

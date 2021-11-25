using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public ItemObject item;
    public int quantity;
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            collider.GetComponent<Player>().theInventory.AddItem(item, quantity);
            Destroy(gameObject);
        }
    }
}

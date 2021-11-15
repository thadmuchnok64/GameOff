using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] protected string itemName;
    [SerializeField] protected int itemID = 0;
    [SerializeField] Sprite icon;
    [TextArea(3, 10)]
    [SerializeField] string itemDescription;

    public virtual string GetName()
    {
        return itemName;
    }

    public virtual int GetID()
    {
        return itemID;
    }

    public virtual Sprite GetIcon()
    {
        return icon;
    }
    public virtual string GetDscription()
    {
        return itemDescription;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject contactedObject = collision.gameObject;
        if(contactedObject.tag == "Player")
        {
            contactedObject.GetComponent<Entity>().GetInventory().AddItem(this);
            

            //Destroy(gameObject);
        }
    }

}

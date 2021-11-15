using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public static ItemList instance;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Multiple item lists!");
            Destroy(this);
        }
    }
    [SerializeField] Items[] listOfItems;

    public  Items GetItem(int id)
    {

        return listOfItems[id];

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfItems : MonoBehaviour
{

    public static ListOfItems instance;
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

    public static Items[] listOfItems;

    public static Items GetItem(int id)
    {

        return listOfItems[id];

    }
}

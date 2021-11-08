using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 5;
    private Rigidbody2D rb;

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
        Debug.Log("Movement success!");
    }


    

}

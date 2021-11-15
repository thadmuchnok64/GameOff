using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected float maxSpeed = 5;
    [SerializeField] protected float acceleration = 15;
    
    protected Rigidbody2D rb;

    protected Entity thisEntity;

    public void ManageForce(Vector2 force)
    {
        rb.AddForce(force);

        if (rb.velocity.magnitude >= maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }        
    }
    
    
    public virtual void Update()
    {
        if (Mathf.Abs(rb.velocity.magnitude) <= 0.01 && (thisEntity.currentState != Entity.EntityStates.DASHING && thisEntity.currentState != Entity.EntityStates.ATTACKING && thisEntity.currentState != Entity.EntityStates.STUNNED && thisEntity.currentState != Entity.EntityStates.PARRYING) && (thisEntity.currentState != Entity.EntityStates.TALKING))
        {
            thisEntity.currentState = Entity.EntityStates.IDLE;
        }
        else if ((Mathf.Abs(rb.velocity.magnitude) >= 0.02) && (thisEntity.currentState != Entity.EntityStates.DASHING && thisEntity.currentState != Entity.EntityStates.ATTACKING && thisEntity.currentState != Entity.EntityStates.STUNNED && thisEntity.currentState != Entity.EntityStates.PARRYING) && (thisEntity.currentState != Entity.EntityStates.TALKING))
        {
            thisEntity.currentState = Entity.EntityStates.WALKING;
        }
        
    }


    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement
{

    public Controls controls;

    private void Awake()
    {
        
        controls.Player.Movement.performed += ctx => AddForce(ctx.ReadValue<Vector2>());
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!");
    }

}

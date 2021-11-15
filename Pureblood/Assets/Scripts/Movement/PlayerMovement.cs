using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Movement
{
    private Vector2 lastDirection;
    private Vector2 mousePos;
    private Controls controls;
    private InputAction movement;
    private Player player;
    private bool canDash = true;
    
    public Camera cam;

    [SerializeField] private float dashCooldown = 0.5f;
    [SerializeField] private float dashStamDrain = 25f;
    [SerializeField] private float dashForce = 30f;
    [SerializeField] private float staminaRegenDelay = 2f;
    [SerializeField] private float IFrames = 0.3f;

    [SerializeField] Animator animator;
    
    public void Awake()
    {
        controls = new Controls();
    }
    private void Start()
    {
        player = gameObject.GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        thisEntity = gameObject.GetComponent<Entity>();
    }

    public override void Update()
    {
        base.Update();
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
    private void OnEnable()
    {
        movement = controls.Player.Movement;
        
        movement.Enable();
        controls.Player.Movement.performed += Movement;

        controls.Player.Dash.performed += Dash;
        controls.Player.Dash.Enable();

        controls.Player.Interact.performed += Interact;
        controls.Player.Interact.Enable();

        controls.Player.Attack.performed += Attack;
        controls.Player.Attack.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    private void FixedUpdate()
    {
        if(player.currentState!=Entity.EntityStates.TALKING)
        ManageForce(movement.ReadValue<Vector2>() * acceleration);
        
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        //lastDirection = movement.ReadValue<Vector2>().normalized;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (player.currentState != Entity.EntityStates.TALKING)
        {

            if (player.GetWeapon() != null && player.GetWeapon().GetID() != 0)
            {
                if (player.GetWeapon().GetType().IsSubclassOf(typeof(MeleeWeapons)))
                {

                    MeleeWeapons weapon = (MeleeWeapons)player.GetWeapon();
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll((Vector3)(mousePos - rb.position).normalized + gameObject.transform.position, weapon.GetAttackRange());
                    foreach (Collider2D enemy in hitEnemies)
                    {
                        if (enemy.tag == "NPC" || enemy.tag == "Enemy")
                        {
                            if (enemy.gameObject.GetComponent<Entity>().currentState != Entity.EntityStates.DEAD)
                            {
                                enemy.GetComponent<Entity>().TakeDamage(player.GetDamage());
                                player.SetPiss(player.GetPiss() + weapon.GetPissGain());
                            }

                        }
                    }
                    player.useStamina(weapon.GetStaminaDrain());
                    if (player.GetCanRegenStamina())
                    {
                        StartCoroutine("PauseStamRegen");
                    }
                }
            }


        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        if (player.currentState != Entity.EntityStates.TALKING)
            lastDirection = movement.ReadValue <Vector2>().normalized;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (player.currentState != Entity.EntityStates.TALKING)
        {
            Debug.Log("fired");
            if (player.GetStamina() >= dashStamDrain && canDash && lastDirection.magnitude != 0)
            {
                rb.AddForce(lastDirection * dashForce, ForceMode2D.Impulse);
                player.useStamina(dashStamDrain);
                StartCoroutine("DashCooldown");
                StartCoroutine("Invincibility");
                if (player.GetCanRegenStamina())
                {
                    StartCoroutine("PauseStamRegen");
                }

            }

        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (player.currentState != Entity.EntityStates.TALKING)
        {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position,mousePos-rb.position, 5f);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "InteractableObject")
                {
                    InteractableObject interactable = hit.collider.gameObject.GetComponent<InteractableObject>();
                    interactable.DoAction();
                }
                else if (hit.collider.tag == "NPC")
                {
                    NPC npc = hit.collider.gameObject.GetComponent<NPC>();
                    npc.TriggerDialogue();
                }

            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector3)(mousePos-rb.position).normalized + gameObject.transform.position, 0.5f);
    }
    IEnumerator DashCooldown()
    {
        canDash = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    IEnumerator PauseStamRegen()
    {
        player.SetCanRegenStamina(false);
        yield return new WaitForSeconds(staminaRegenDelay);
        player.SetCanRegenStamina(true);
    }

    IEnumerator Invincibility()
    {
        player.currentState = Entity.EntityStates.DASHING;
        yield return new WaitForSeconds(IFrames);
        player.currentState = Entity.EntityStates.IDLE;
    }
    
}

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
    private bool inAnActiveState = false;

    public Material dashMat;
    protected SpriteRenderer spriteRenderer;
    protected ParticleSystem dashParticles;
    public Camera cam;

    [SerializeField] private float dashCooldown = 0.5f;
    [SerializeField] private float dashStamDrain = 25f;
    [SerializeField] private float dashForce = 30f;
    [SerializeField] private float staminaRegenDelay = 2f;
    [SerializeField] private float IFrames = 0.3f;
    [SerializeField] private float parryCooldown = 0.4f;

    [SerializeField] private GameObject bullet;
    [SerializeField] private ConsumableObject bulletObject;
    [SerializeField] private GameObject swoosh;
    [SerializeField] GameObject gunParticles;

    
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
        spriteRenderer = GetComponent<SpriteRenderer>();
        dashParticles = GetComponent<ParticleSystem>();
    }

    public override void Update()
    {
        base.Update();
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Debug.Log(player.currentState);
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

        controls.Player.Parry.performed += Parry;
        controls.Player.Parry.Enable();
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
        //rb.rotation = angle;
        animator.SetFloat("Horizontal", lookDir.normalized.x);
        animator.SetFloat("Vertical", lookDir.normalized.y);
        if(Mathf.Abs(rb.velocity.magnitude) > 0.05)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        //lastDirection = movement.ReadValue<Vector2>().normalized;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (player.currentState != Entity.EntityStates.TALKING && player.currentState != Entity.EntityStates.ATTACKING && !inAnActiveState)
        {

            if (player.GetWeapon() != null && player.GetWeapon().description != "")
            {
                animator.runtimeAnimatorController = player.GetWeapon().animatorOverrideController;
                if (player.GetWeapon().weaponType == WeaponObject.WeaponType.Melee && player.GetWeapon().staminaDrain <= player.GetStamina())
                {
                    
                    WeaponObject weapon = player.equippedWeapon;
                    StartCoroutine(AttackCooldown(weapon.cooldown));
                    //swoosh
                    //GameObject theSwoosh = Instantiate(swoosh, (Vector3)(mousePos - rb.position).normalized + gameObject.transform.position, gameObject.transform.rotation);
                    //Vector3 v = (mousePos - (Vector2)transform.position);
                    //float rot = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
                    //theSwoosh.transform.rotation = Quaternion.Euler(0f, 0f, rot + 180);

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
                else if(player.GetWeapon().weaponType == WeaponObject.WeaponType.Ranged)
                {
                    WeaponObject weapon = player.equippedWeapon;
                    for(int i = 0; i < player.theInventory.Container.Count; i++)
                    {
                        if(player.theInventory.Container[i].item == bulletObject && player.theInventory.Container[i].SubtractAmount(1))
                        {
                            SoundMaster.instance.PlayRandomSound(weapon.attackSounds);
                            StartCoroutine(AttackCooldown(weapon.cooldown));
                            ManageForce((rb.position-mousePos).normalized*weapon.weight);
                            StartCoroutine(BulletGen(weapon));

                            CameraScript.instance.AddRumble(weapon.recoilAmount);
                            if(player.theInventory.Container[i].amount == 0)
                            {
                                player.theInventory.Container.RemoveAt(i);
                            }
                        }
                        else
                        {
                            SoundMaster.instance.PlayRandomSound(weapon.drySounds);
                        }
                    }
                    
                }
            }


        }
    }


    IEnumerator BulletGen(WeaponObject weapon)
    {
        Instantiate(gunParticles, (Vector3)(mousePos - rb.position).normalized + gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(.01f);
        for (int y = 0; y < weapon.projectileAmount; y++)
        {

            GameObject theBullet = Instantiate(weapon.bulletObject, (Vector3)(mousePos - rb.position).normalized + gameObject.transform.position, gameObject.transform.rotation);

            Vector3 v = (mousePos - (Vector2)transform.position);

            float rot = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            theBullet.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-weapon.spread, weapon.spread) + rot);

            // theBullet.transform.eulerAngles = new Vector3(0, 0, theBullet.transform.eulerAngles.z + Random.Range(-weapon.spread,weapon.spread));
            theBullet.GetComponent<BulletScript>().Spawn(Player.instance.GetDamage(), weapon.pissMeterGain);
            theBullet.GetComponent<Rigidbody2D>().AddForce((30f + Random.Range(0, weapon.spread / 3f)) * theBullet.transform.right, ForceMode2D.Impulse);
            theBullet.transform.position += new Vector3(Random.Range(-weapon.spread / 35f, weapon.spread / 35f), Random.Range(-weapon.spread / 35f, weapon.spread / 35f));
            yield return new WaitForSeconds(.0075f);
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        if (player.currentState != Entity.EntityStates.TALKING)
            lastDirection = movement.ReadValue <Vector2>().normalized;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (player.currentState != Entity.EntityStates.TALKING && !inAnActiveState)
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

    public void Parry(InputAction.CallbackContext context)
    {
        if(player.currentState != Entity.EntityStates.TALKING && !inAnActiveState)
        {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, mousePos - rb.position, 2f);
            StartCoroutine(ParryCooldown());
            if (hit.collider != null)
            {
                if(hit.collider.tag == "NPC")
                {
                    NPCMovement npc = hit.collider.gameObject.GetComponent<NPCMovement>();
                    npc.AttemptToParry();
                }

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.DrawWireSphere((Vector3)(mousePos-rb.position).normalized + gameObject.transform.position, 0.5f);
    }
    IEnumerator DashCooldown()
    {
        inAnActiveState = true;
        canDash = false;
        yield return new WaitForSeconds(dashCooldown);
        inAnActiveState = false;
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
        inAnActiveState = true;
        yield return new WaitForSeconds(IFrames);
        inAnActiveState = false;
        player.currentState = Entity.EntityStates.IDLE;
    }

    IEnumerator AttackCooldown(float duration)
    {
        player.currentState = Entity.EntityStates.ATTACKING;
        inAnActiveState = true;
        animator.Play("Attacking");
        yield return new WaitForSeconds(duration);
        inAnActiveState = false;
        player.currentState = Entity.EntityStates.IDLE;
    }

    IEnumerator ParryCooldown()
    {
        player.currentState = Entity.EntityStates.PARRYING;
        inAnActiveState = true;
        yield return new WaitForSeconds(parryCooldown);
        inAnActiveState = false;
        player.currentState = Entity.EntityStates.IDLE;
       
    }
    
}

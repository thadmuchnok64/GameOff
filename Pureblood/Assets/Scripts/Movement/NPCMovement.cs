using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : Movement
{

    NPC npc;

    [Tooltip("You can add some patrol points if you want, here. This makes it so the NPC will walk between points when idle.")]
    [SerializeField] Transform[] patrolPoints;
    private Transform walkTarget;
    [Header("Combat")]
    [Tooltip("If hostile approached by hostile entity, how close should it get before the NPC starts attacking it..")]
    [SerializeField] int agroRange = 10;
    [SerializeField] int agroMaximumRange = 40;
    private bool agrod = false;
    [SerializeField] int attackRange;
    [SerializeField] int attackStaminaCost;
    [SerializeField] float attackDelay;
    [SerializeField] int parryFrames;
    [SerializeField] float attackCooldown;

    private bool parried;
    private float stunTime;
    private float staminaRegenDelay;
    private int patrolIndex = 0;
    private float attackTimer = 0;

    private Coroutine attacking;

    [SerializeField] Animator animator;




    // Start is called before the first frame update
    private void Start()
    {
        npc = GetComponent<NPC>();
        rb = GetComponent<Rigidbody2D>();
        staminaRegenDelay = .5f;//npc.GetEndurance();
        //npc.GetInventory().EquipWeapon(0, new Sword());
        thisEntity = npc;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        AI(Time.fixedDeltaTime);
        attackTimer -= Time.fixedDeltaTime;

        if (animator != null)
        {

            if (Mathf.Abs(rb.velocity.magnitude) > 0.05)
            {
                animator.SetFloat("Horizontal", rb.velocity.normalized.x);
                animator.SetFloat("Vertical", rb.velocity.normalized.y);
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }

    }

    public virtual void AI(float time)
    {
        if (npc.currentState == Entity.EntityStates.TALKING)
        {
            if (Player.instance.currentState != Entity.EntityStates.TALKING)
            {
                npc.currentState = Entity.EntityStates.IDLE;
            }
        }
        else if (CheckHostility())
        {
            if (npc.currentState == Entity.EntityStates.IDLE)
            {
                npc.currentState = Entity.EntityStates.WALKING;


            }
            else if (npc.currentState == Entity.EntityStates.WALKING)
            {

                ManageForce((Player.instance.transform.position - transform.position).normalized * acceleration);

                if (Vector2.Distance(Player.instance.transform.position, transform.position) > attackRange)
                {
                    walkTarget = Player.instance.transform;
                }
                else
                {
                    if (attackTimer < 0)
                    {
                        npc.useStamina(attackStaminaCost);
                        attacking = StartCoroutine(AttackCoroutine());
                        attackTimer = attackCooldown;
                    }


                }
            }
            else if (npc.currentState == Entity.EntityStates.STUNNED)
            {
                stunTime -= time;
                if (stunTime <= 0)
                {
                    stunTime = 0;
                    npc.currentState = Entity.EntityStates.IDLE;
                }
            }


        }
        else
        {
            if (patrolPoints.Length > 0)
            {
                walkTarget = patrolPoints[patrolIndex];
                if (WalkToPoint(walkTarget))
                {
                    patrolIndex++;
                    if (patrolIndex >= patrolPoints.Length)
                    {
                        patrolIndex = 0;
                    }
                }

            }
        }
    }



    private bool WalkToPoint(Transform point)
    {
        ManageForce((((Vector2)point.position-(Vector2)transform.position).normalized)*acceleration);
        if (Vector2.Distance(point.position, transform.position) < .2f)
        {
            return true;
        }
        return false;
    }

    IEnumerator AttackCoroutine()
    {
        npc.currentState = Entity.EntityStates.ATTACKING;
        yield return new WaitForSeconds(attackDelay);
        npc.currentState = Entity.EntityStates.PARRYABLE;
        for (int i = 0; i < parryFrames; i++)
        {
            yield return new WaitForFixedUpdate();
        }
        if (parried)
        {
            parried = false;
            npc.currentState = Entity.EntityStates.STUNNED;
            // in the future we might want to consider amending this.
            // Maybe player with more strength means longer parry stuns, wheras enemies with higher CON means lower parry stuns
            stunTime += 3-Mathf.Log(npc.GetConstitution(),10);
            if (stunTime < .5)
                stunTime = .5f;
        }
        else
        {

            //maybe change this in the future to let NPCs swap between weapons.
            if (npc.GetInventory().equippedWeapons[0].item.description != "")
            {
                WeaponObject weapon = npc.GetInventory().equippedWeapons[0].item as WeaponObject;
                if (weapon.weaponType == WeaponObject.WeaponType.Melee)
                {

                    //MeleeWeapons weapon = (MeleeWeapons)npc.GetInventory().GetEquippedWeapons()[0];
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(gameObject.transform.position + (Player.instance.transform.position - transform.position).normalized * 2f, weapon.GetAttackRange());
                    foreach (Collider2D enemy in hitEnemies)
                    {
                        if (enemy.tag == "Entity" || enemy.tag == "Player")
                        {
                            if (enemy.gameObject.GetComponent<Entity>().currentState != Entity.EntityStates.DEAD)
                            {
                                enemy.GetComponent<Entity>().TakeDamage(npc.GetDamage());
                            }

                        }
                    }
                    npc.useStamina(weapon.GetStaminaDrain());
                    if (npc.GetCanRegenStamina())
                    {
                        StartCoroutine("PauseStamRegen");
                    }
                }
            }
            yield return new WaitForSeconds(attackDelay/2);
            npc.currentState = Entity.EntityStates.IDLE;

            Player.instance.TakeDamage(npc.GetDamage());

        }

    }


    public bool AttemptToParry()
    {
        if (npc.currentState == Entity.EntityStates.PARRYABLE)
        {
            parried = true;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns true if the npc should attack the player.
    /// </summary>
    /// <returns></returns>
    private bool CheckHostility()
    {
        if (!npc.hostile)
            return false;
        if (!agrod)
        {
            if (Vector2.Distance(Player.instance.transform.position, transform.position) < agroRange)
            {
                agrod = true;
                return true;
            }
            return false;
        }
        else
        {
            if(Vector2.Distance(Player.instance.transform.position, transform.position) > agroMaximumRange)
            {
                agrod = false;
                return false;
            }
                
            return true;
        }
    }

        IEnumerator PauseStamRegen()
        {
            npc.SetCanRegenStamina(false);
            yield return new WaitForSeconds(staminaRegenDelay);
            npc.SetCanRegenStamina(true);
        }


    }

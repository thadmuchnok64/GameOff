using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Entity
{
    private int immunity = 2;
    Coroutine hostility;
    [Header("NPC Parameters")]
    [SerializeField] new string name = "Creature";
    public bool hostile;
    [SerializeField] int purityDroppedOnDeath = 50;
    private bool purityConsumed = false;

    private Container inventory;
    [HideInInspector]
    public DialogueTrigger dt;
    [SerializeField] int questFinishedOnDeath = -1;
    [SerializeField] bool permanentlyDies = true;
    Animator animator;


    public void ResurectAllNPCs()
    {
        if(!permanentlyDies)
        {
            health = GetMaxHealth();
            currentState = EntityStates.IDLE;
            animator.Play("Idle");
        }
    }

    public override void Awake()
    {
        dt = GetComponent<DialogueTrigger>();
        base.Awake();
        animator = gameObject.GetComponent<Animator>();
    }

    public override void TakeDamage(float damage)
    {


        if (gameObject.tag == "NPC")
        {
            dt.StartCoroutine(dt.SendHurtDialogue());
            immunity--;
            if (immunity == 0)
            {
                gameObject.tag = "Enemy";
                hostile = true;
            }
            else
            {
                if (hostility != null)
                {
                    StopCoroutine(hostility);
                }
                hostility = StartCoroutine(HostilityCooldown(30));
            }
        }
        else
        {
            if (currentState!=EntityStates.DEAD && Random.Range(1, 4) == 1)
            {
                dt.StartCoroutine(dt.SendHurtDialogue());
            }
        }
        if(hostile)
        base.TakeDamage(damage);
        if (GetHealth() <= 0)
        {
            if(questFinishedOnDeath!=-1)
            QuestManager.instance.SetQuestToComplete(questFinishedOnDeath);
            if (!purityConsumed)
            {
                purityConsumed = true;
                Player.instance.AddPurity(purityDroppedOnDeath);
            }
        }
    }


    IEnumerator HostilityCooldown(int x)
    {
        yield return new WaitForSeconds(x);
        if (gameObject.tag == "NPC")
        {
            immunity = 2;
        }
    }

    public virtual void TriggerDialogue()
    {
        DialogueTrigger dt = GetComponent<DialogueTrigger>();
        if (dt != null)
        {
            if (theInventory is Shop)
            {
                dt.DoShop(theInventory as Shop);

            }
            else
            {
                dt.DoAction();
            }
        }
    }


    public string GetName()
    {
        return name;
    }

}

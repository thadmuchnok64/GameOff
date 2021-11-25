using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Entity
{
    private int immunity = 3;
    Coroutine hostility;
    [Header("NPC Parameters")]
    [SerializeField] string name = "Creature";
    public bool hostile;

    private Container inventory;
    public override void TakeDamage(float damage)
    {
        if (gameObject.tag == "NPC")
        {
            immunity--;
            if (immunity == 0)
            {
                gameObject.tag = "Enemy";
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
        base.TakeDamage(damage);
    }


    IEnumerator HostilityCooldown(int x)
    {
        yield return new WaitForSeconds(x);
        if (gameObject.tag == "NPC")
        {
            immunity = 3;
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

}

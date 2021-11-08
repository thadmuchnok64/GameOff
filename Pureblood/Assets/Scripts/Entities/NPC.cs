using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Entity
{
    private int immunity = 3;
    Coroutine hostility;
    [SerializeField] string name = "Creature";
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

}

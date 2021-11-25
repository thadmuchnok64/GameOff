using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float pissGain;
    private float damage = 0;
    public void Spawn(float _damage, float _piss)
    {
        damage = _damage;
        pissGain = _piss;
        Destroy(gameObject, 3);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "NPC" || collision.tag == "Enemy")
        {
            if(collision.GetComponent<Entity>().currentState != Entity.EntityStates.DEAD)
            {
                collision.GetComponent<Entity>().TakeDamage(damage);
                Player.instance.SetPiss(Player.instance.GetPiss() + pissGain);
                Destroy(gameObject);
            }
            
        }
    }
}

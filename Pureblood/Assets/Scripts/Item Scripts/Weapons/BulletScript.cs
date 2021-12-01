using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float pissGain;
    private float damage = 0;
    private bool hurtsPlayer = false;
    public GameObject blood;
    public AudioClip[] parried;
    public void Spawn(float _damage, float _piss)
    {
        damage = _damage;
        pissGain = _piss;
        Destroy(gameObject, 4);
        
    }
    public void Spawn(float _damage, float _piss, bool harmsPlayer)
    {
        damage = _damage;
        pissGain = _piss;
        hurtsPlayer = harmsPlayer;
        Destroy(gameObject, 4);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hurtsPlayer && collision.tag == "Player")
        {
            //maybe we should add something here to let the player parry bullets?
            if (collision.GetComponent<Entity>().currentState != Entity.EntityStates.DEAD)
            {
                collision.GetComponent<Entity>().TakeDamage(damage);
                if (collision.GetComponent<Entity>().currentState == Entity.EntityStates.PARRYING)
                {
                    SoundMaster.instance.PlayRandomSound(parried);
                    collision.GetComponent<PlayerMovement>().inAnActiveState = false;
                    gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity * -1;
                }
                else if (collision.GetComponent<Entity>().currentState != Entity.EntityStates.DASHING)
                {
                    Destroy(gameObject);
                }
                
            }
            
        }
        else if(collision.tag == "NPC" || collision.tag == "Enemy")
        {
            if(collision.GetComponent<Entity>().currentState != Entity.EntityStates.DEAD)
            {
                GameObject theBlood = Instantiate(blood, collision.transform);
                Destroy(theBlood, 1f);
                collision.GetComponent<Entity>().TakeDamage(damage);
                collision.attachedRigidbody.AddForce(gameObject.GetComponent<Rigidbody2D>().velocity.normalized * 10, ForceMode2D.Impulse);
                Player.instance.SetPiss(Player.instance.GetPiss() + pissGain);
                Destroy(gameObject);
            }
            
        }
    }
}

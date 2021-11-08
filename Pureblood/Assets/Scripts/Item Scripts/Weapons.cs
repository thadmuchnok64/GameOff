using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : Items
{
    protected float damage;
    [SerializeField] protected float baseDamage;
    [SerializeField] protected float scaling;
    [SerializeField] protected string scalingStat;
    [SerializeField] protected float pissMeterMod;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void calcDamage(int strength, int dexterity, int divinity)
    {
        //calculate damage scaling per weapon by passing in
        //damage = baseDamage + (strength/dextirity/divinity * 0.5f)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Entity>().TakeDamage(damage);
        }
    }

    public float GetDamage()
    {
        return damage;
    }
}
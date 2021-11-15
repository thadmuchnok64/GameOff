using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : Consumables
{
    int buffAmount = 5;
    float duration = 40f;
 
    public override void useItem()
    {
        Player.instance.StartCoroutine(Player.instance.BuffStregnth(buffAmount, duration));
        Debug.Log(Player.instance.GetStrength());
        
    } 
}

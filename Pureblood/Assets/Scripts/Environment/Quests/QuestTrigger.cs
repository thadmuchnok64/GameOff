using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public Quest[] quests;


    /*
     * 
     * Old function used to test quests
     * 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            QuestManager.instance.AddQuest(quests[0]);
            //Debug.Log("quest given");
        }
    }
    */


        /*
         *  Outdated quest function
         *  
    public void GiveQuest(int x)
    {
        if (x >= quests.Length)
        {
            Debug.Log(gameObject.name + " does not have a quest for index " + x + ".");
        }
        else
        {
            QuestManager.instance.AddQuest(quests[x]);
        }
    }
    */
}

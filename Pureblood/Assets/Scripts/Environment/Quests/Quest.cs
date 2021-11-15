using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    [Header("Quest")]
    public string questName;
    public string questDescription;
    public int questID;
    public bool isActive;
    public bool isFinished = false;
    public string nameOfQuestGiver;

    [Header("Rewards")]
    public int purity;
    public int[] rewardItemsIDs;
    public int[] rewardItemQuantities;

}

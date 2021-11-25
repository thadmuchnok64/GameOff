using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest 
{
    [Header("Quest")]
    public string questName;
    [TextArea(3,10)]
    public string questDescription;
    public int questID;
    public bool isActive;
    public bool isFinished = false;
    public string nameOfQuestGiver;

    [Header("Rewards")]
    public int purity;
    public ItemObject[] rewardItems;
    public int[] rewardQuantities;

    [Header("More Objectives")]
    public string[] alternativeObjectives;
    [TextArea(3, 10)]
    public string[] alternativeDescriptions;
    public int phase = 0;




}

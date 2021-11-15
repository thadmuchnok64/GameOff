using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBranch : DialogueBranch
{
    public int questID;

    public override int GetGivenQuestID()
    {

        return questID;
    }
}

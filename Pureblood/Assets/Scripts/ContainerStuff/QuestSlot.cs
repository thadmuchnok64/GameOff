using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSlot : MonoBehaviour
{
    private Quest quest = new Quest();
    [Header("Necessary for all quest slots")]
    [SerializeField] TMPro.TextMeshProUGUI questNameText;

    [Header("Stuff only for main slot")]
    [SerializeField] TMPro.TextMeshProUGUI questDescriptionText;
    [SerializeField] TMPro.TextMeshProUGUI activity;
    [SerializeField] TMPro.TextMeshProUGUI rewards;
    [SerializeField] TMPro.TextMeshProUGUI questGiver;
    [SerializeField] ItemSlot[] itemRewards;





    public void SetQuest(Quest q)
    {
        quest = q;
        if (questNameText != null)
            questNameText.text = "" + q.questName;
        if (questDescriptionText != null)
            questDescriptionText.text = "" + q.questDescription;
        if (activity != null)
        {
            if (q.isActive)
            {
                activity.text = "Active";
            } else
            {
                activity.text = "Complete";
            }
        }
        if (rewards != null)
        {
            if (q.purity >= 0)
            {
                rewards.text = "" + q.purity + " Purity";
            }
            else
            {
                rewards.text = "" + Mathf.Abs(q.purity) + " Corruption";

            }
        }
        if (questGiver != null)
        {
            questGiver.text = "Given by "+ q.nameOfQuestGiver;
        }
    }
    public Quest GetQuest()
    {
        return quest;
    }


    public void SendToQuestManager()
    {
        QuestManager.instance.SetSelectedQuest(GetQuest());
    }

}

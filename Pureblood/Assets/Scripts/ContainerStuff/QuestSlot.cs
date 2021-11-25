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
    //private ItemObject[] items;
    //private int[] quantities;





    public void SetQuest(Quest q)
    {
        quest = q;
        if (questNameText != null)
            questNameText.text = "" + q.questName;
        if (questDescriptionText != null)
            questDescriptionText.text = "" + q.questDescription;
        else
        {
            questNameText.text = "> " + questNameText.text;
        }
        if (activity != null)
        {
            if (!q.isFinished)
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
            if (questGiver.text != "" || questGiver.text != "n/a")
            {
                questGiver.text = "Given by " + q.nameOfQuestGiver;
            } else
            {
                questGiver.text = "";
            }
        }
        if (itemRewards.Length>0)
        {

            int i;
            for(i= 0; i < quest.rewardItems.Length; i++)
            {
                
                itemRewards[i].gameObject.SetActive(true);
                itemRewards[i].SetItem(q.rewardItems[i],q.rewardQuantities[i]);
            }
            if (i < 3)
            {
                for(int y = i; y < 3; y++)
                {
                    itemRewards[y].gameObject.SetActive(false);
                }
            }
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

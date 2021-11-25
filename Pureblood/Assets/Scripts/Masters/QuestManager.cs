using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    [SerializeField] QuestSlot[] questListSlots;
    [SerializeField] private QuestSlot slot;
    [SerializeField] Quest[] questList;
    List<Quest> listOfActiveQuests;
    List<Quest> listOfCompleteQuests;
    

    public static QuestManager instance;

        private void Awake()
    {
        listOfActiveQuests = new List<Quest>();
        listOfCompleteQuests = new List<Quest>();
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Debug.Log("Multiple instances of quest manager");
            Destroy(this);
        }

        InvokeRepeating("UpdateQuests", 3, 2);
        //InvokeRepeating("CheckQuestConditions", 5, .5f);
    }


 



    public void SetSelectedQuest(Quest q)
    {
        slot.SetQuest(q);
    }

    public void UpdateQuests()
    {

        SortQuests(listOfActiveQuests.ToArray());
    }

    public bool AddQuest(int id)
    {
        
        foreach(Quest quest in listOfActiveQuests)
        {
            if (quest.questID == id)
            {
                Debug.Log("Attempted to give a quest with an identical ID to an already active quest.");
                return false;
            }
        }
        if (id < questList.Length)
        {
            questList[id].isActive = true;
            listOfActiveQuests.Add(questList[id]);
        }
        else
        {
            Debug.Log("Invalid quest id given.");
            return false;
        }

        return true;
    }

    private void SortQuests(Quest[] x)
    {
        for (int i = 0; i < questListSlots.Length; i++)
        {
            if (i >= x.Length)
            {
                questListSlots[i].gameObject.SetActive(false);
            }
            else
            {
                questListSlots[i].gameObject.SetActive(true);
                questListSlots[i].SetQuest(x[i]);
            }
        }
    }
    // Gonna be a behemoth of a switch statement.
    public void SetQuestToComplete(int questID)
    {
        int i = 0;
        foreach(Quest q in listOfActiveQuests)
        {

            if (q.questID == questID)
            {
                q.isActive = false;
                q.isFinished = true;
                GiveQuestRewardsToPlayer(q);
                listOfCompleteQuests.Add(q);
                listOfActiveQuests.RemoveAt(i);
                return;
            }

            i++;

            /*
            switch (q.questID)
            {
                case 1:
                    //spaghetti
                    break;
                default:
                    Debug.Log("No quest condition set for questID: " + q.questID);
                    break;
            }
            */
        }
    }

    private void GiveQuestRewardsToPlayer(Quest q)
    {
        Player.instance.AddPurity(q.purity);
        for (int i = 0; i < q.rewardItems.Length;i++)
        {
            Player.instance.theInventory.AddItem(q.rewardItems[i], 1);
            /*
            if (q.rewardItems[i].GetType().IsSubclassOf(typeof(ConsumableObject)))
            {
                Consumables c = ItemList.instance.GetItem(q.rewardItemsIDs[i]) as Consumables;
                c.AddQuantity(q.rewardItemQuantities[i]);
            }
            else if (ItemList.instance.GetItem(q.rewardItemsIDs[i]).GetType().IsSubclassOf(typeof(Weapons)))
            {
                Weapons c = ItemList.instance.GetItem(q.rewardItemsIDs[i]) as Weapons;
            }
            */
            //Player.instance.GetInventory().AddItem(ItemList.instance.GetItem(q.rewardItemsIDs[i]));

        }
    }

}

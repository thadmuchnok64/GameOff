using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : InteractableObject
{
    [SerializeField] ItemObject healingItem;
    public override void DoAction()
    {
        Player.instance.bonfireLastRestedAt = this;

        NPC[] npcs = (NPC[])FindObjectsOfType(typeof(NPC));

            foreach(NPC n in npcs)
        {
            n.ResurectAllNPCs();
        }
        Player.instance.Heal(Mathf.RoundToInt(Player.instance.GetMaxHealth()));
        bool hasHealingItem = false;
        foreach(InventorySlot item in Player.instance.theInventory.Container)
        {
            if (item.item == healingItem)
            {
                hasHealingItem = true;
                item.amount = healingItem.maxStackAmount;
            }
            
        }
        if(!hasHealingItem)
        {
            Player.instance.theInventory.AddItem(healingItem, healingItem.maxStackAmount);
        }
        Player.instance.currentState = Entity.EntityStates.IDLE;
        

    }

    public void TeleportToBonfire()
    {
        UIControls.instance.Transtion();
        Player.instance.transform.position = transform.position;
        DoAction();
    }


}

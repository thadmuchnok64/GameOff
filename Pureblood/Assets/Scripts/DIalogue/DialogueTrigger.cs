using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : InteractableObject
{
    //public string name;
    public DialogueGraph[] dialogueGraph;
    public List<Transform> extraTransform;

    [Header("Common Dialogue")]
    public string[] secondaryDialogues;
    [SerializeField] bool automaticallyInitiatesDialogue;
    private int dialogueIteration;
    private bool secondaryCooldown = false;

    private void Awake()
    {
        dialogueIteration = 0;
        extraTransform.Insert(0, transform);
        if(automaticallyInitiatesDialogue||secondaryDialogues.Length>0)
        InvokeRepeating("CheckIfPlayerNearby", 1, 1);
    }

    public override void DoAction()
    {
        if (dialogueIteration < dialogueGraph.Length)
        {
            if (dialogueGraph != null)
            {
                DialogueManager.instance.StartDialogue(dialogueGraph[dialogueIteration], extraTransform.ToArray());
                if (GetComponent<Entity>() != null)
                {
                    GetComponent<Entity>().currentState = Entity.EntityStates.TALKING;
                    Player.instance.currentState = Entity.EntityStates.TALKING;
                }
            }
            dialogueIteration++;
        }
        base.DoAction();
    }
    private void CheckIfPlayerNearby()
    {
        if (secondaryDialogues.Length>0 && secondaryCooldown == false)
        {
            if(Vector2.Distance(Player.instance.transform.position,transform.position)<7)
            StartCoroutine(SendSecondaryDialogue());
        }
        if (automaticallyInitiatesDialogue && dialogueIteration < dialogueGraph.Length) 
        {
            if (Vector2.Distance(Player.instance.transform.position, transform.position) < 7)
                DoAction();
        }
    }
    private IEnumerator SendSecondaryDialogue()
    {
        secondaryCooldown = true;
        DialogueManager.instance.StartIndirectDialogue(secondaryDialogues[Random.Range(0, secondaryDialogues.Length)], transform);
        yield return new WaitForSeconds(Random.Range(18f,30f));
        secondaryCooldown = false;
    }
    

    public void DoShop(Shop s)
    {
        DialogueManager.instance.shop = s;
        DoAction();
    }
}

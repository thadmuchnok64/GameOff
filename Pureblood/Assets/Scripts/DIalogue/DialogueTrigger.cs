using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : InteractableObject
{
    //public string name;
    public DialogueGraph[] dialogueGraph;
    public List<Transform> extraTransform;
    public List<NPC> extraNPCs;

    [Header("Common Dialogue")]
    public string[] secondaryDialogues;
    public string[] painDialogues = { "Aaaugh!","Ow!","God that hurt...","Ouch!","That one hit different.","Cut it out!!!","I think that one hit a bone.","Oh god... is that blood?" };
    public string[] hostileDialogues = { "I'm gonna kill you!", "Die! Die! Die!", "Go to hell!", "I'm ending you now.", "Die, scum!", "Hahaha you suck!", "You're going six feet under", "Lets finish this!" };
    public string[] fleeingDialogues = { "Leave me alone!", "Go away!", "Someboy help!","I'm being attacked! Help!","Somebody get the law!","Stop! Please!","Get me a doctor!"};
    [SerializeField] bool automaticallyInitiatesDialogue;
    [HideInInspector]
    public int dialogueIteration;
    private bool secondaryCooldown = false;
    [SerializeField] bool scalesDialogue = true;

    private void Awake()
    {
        dialogueIteration = 0;
        extraTransform.Insert(0, transform);
        extraNPCs.Insert(0,GetComponent<NPC>());
        if(automaticallyInitiatesDialogue||secondaryDialogues.Length>0)
        InvokeRepeating("CheckIfPlayerNearby", 1, 1);
    }

    public override void DoAction()
    {
        if (dialogueIteration < dialogueGraph.Length)
        {
            if (dialogueGraph != null)
            {
                DialogueManager.instance.StartDialogue(dialogueGraph[dialogueIteration], extraTransform.ToArray(),extraNPCs.ToArray());
                if (GetComponent<Entity>() != null)
                {
                    GetComponent<Entity>().currentState = Entity.EntityStates.TALKING;
                    Player.instance.currentState = Entity.EntityStates.TALKING;
                }
            }
            if(scalesDialogue)
            dialogueIteration++;
        }
        base.DoAction();
    }
    private void CheckIfPlayerNearby()
    {
        if (secondaryDialogues.Length>0 && secondaryCooldown == false)
        {
            if(Vector2.Distance(Player.instance.transform.position,transform.position)<6)
            StartCoroutine(SendSecondaryDialogue());
        }
        if (automaticallyInitiatesDialogue && dialogueIteration < dialogueGraph.Length) 
        {
            if (Vector2.Distance(Player.instance.transform.position, transform.position) < 6)
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

    public IEnumerator SendFleeingDialogue()
    {
        if (fleeingDialogues.Length > 0)
        {
            secondaryCooldown = true;
            DialogueManager.instance.OverrideDialogue(fleeingDialogues[Random.Range(0, fleeingDialogues.Length)], transform);
            yield return new WaitForSeconds(Random.Range(4f, 10f));
            secondaryCooldown = false;
        }
    }

    public IEnumerator SendHurtDialogue()
    {
        if (painDialogues.Length > 0)
        {
            secondaryCooldown = true;
            DialogueManager.instance.OverrideDialogue(painDialogues[Random.Range(0, painDialogues.Length)], transform);
            yield return new WaitForSeconds(Random.Range(4f, 10f));
            secondaryCooldown = false;
        }
    }

    public IEnumerator SendHostileDialogue()
    {
        if (hostileDialogues.Length > 0)
        {
            secondaryCooldown = true;
            DialogueManager.instance.OverrideDialogue(hostileDialogues[Random.Range(0, hostileDialogues.Length)], transform);
            yield return new WaitForSeconds(Random.Range(4f, 10f));
            secondaryCooldown = false;
        }
    }

    public void DoShop(Shop s)
    {
        DialogueManager.instance.shop = s;
        DoAction();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueTrigger : InteractableObject
{

    [SerializeField] string dialogue;
    public override void DoAction()
    {
        DialogueManager.instance.OverrideDialogue(dialogue,Player.instance.transform);
        base.DoAction();
        Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DoAction();
        }
    }
}

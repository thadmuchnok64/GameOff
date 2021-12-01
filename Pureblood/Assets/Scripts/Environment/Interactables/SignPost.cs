using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : InteractableObject
{
    [SerializeField] string signText;

    public override void DoAction()
    {
        DialogueManager.instance.OverrideDialogue(signText,transform);
       // base.DoAction();
    }
}

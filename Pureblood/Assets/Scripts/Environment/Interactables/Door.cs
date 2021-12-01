using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] Transform positionToTeleportTo;
    public string locationName;
    

    public override void DoAction()
    {
        UIControls.instance.Transtion();
        StartCoroutine(WaitForTransition());
        //base.DoAction();
    }

    private IEnumerator WaitForTransition()
    {
        yield return new WaitForSeconds(.15f);
        Player.instance.transform.position = positionToTeleportTo.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DoAction();
        }
    }

}

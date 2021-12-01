using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStart : InteractableObject
{
    [SerializeField] AudioClip clip;
    private AudioSource aud;
    private bool activated = false;
    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public override void DoAction()
    {
        activated = true;
        SoundMaster.instance.PlayMusic(clip,aud);
        base.DoAction();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activated)
        {
            if (collision.tag == "Player")
            {
                DoAction();
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMaster : MonoBehaviour
{

    public float musicVolume = 1f;
    public float soundVolume = 1f;

    public static SoundMaster instance;
    [SerializeField] AudioSource aud;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Multiple instances of a SoundMaster singleton! Fix this!");
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Play a sound. Calculates volume and if sound can play and stuff.
    /// </summary>
    /// <param name="AC"></param>
    public void PlaySoundEffect(AudioClip ac, AudioSource AS)
    {
        PlaySound(ac, AS, soundVolume);
    }

    public void PlayMusic(AudioClip ac, AudioSource AS)
    {
        PlaySound(ac, AS, musicVolume);
    }


    private void PlaySound(AudioClip ac, AudioSource AS, float volume)
    {
        AS.PlayOneShot(ac, volume);
    }

    public void PlayRandomSound(AudioClip[] ac)
    {
        PlaySound(ac[Random.Range(0, ac.Length)],aud,soundVolume);
    }


}

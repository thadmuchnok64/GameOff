using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMaster : MonoBehaviour
{

    public float musicVolume = 1f;
    public float soundVolume = 1f;
    public AudioMixer music;
    public AudioMixer sfx;
    public static SoundMaster instance;
    [SerializeField] AudioSource aud;
    [SerializeField] AudioSource musicAudio;
    public AudioClip basicCombatMusic;
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

    private void Start()
    {
        music.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("volume", 0.5f)) * 20);
        sfx.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("SFX", 0.5f)) * 20);
    }
    /// <summary>
    /// Play a sound. Calculates volume and if sound can play and stuff.
    /// </summary>
    /// <param name="AC"></param>
    public void PlaySoundEffect(AudioClip ac, AudioSource AS)
    {
        PlaySound(ac, AS, soundVolume);
    }

    public void PlaySoundEffect(AudioClip ac)
    {
        aud.PlayOneShot(ac);
    }

    public void PlayMusic(AudioClip ac, AudioSource AS)
    {
        //PlaySound(ac, AS, musicVolume);
        AS.clip = ac;
        AS.loop = true;
        AS.volume = musicVolume;
        AS.Play();
    }


    private void PlaySound(AudioClip ac, AudioSource AS, float volume)
    {
        AS.PlayOneShot(ac, volume);
    }

    public void PlayRandomSound(AudioClip[] ac)
    {
        PlaySound(ac[Random.Range(0, ac.Length)],aud,soundVolume);
    }

    public IEnumerator FadeInMusic(AudioClip ac)
    {
        float timeElapsed = 0;
        float lerpDuration = 2.0f;
        musicAudio.clip = ac;
        musicAudio.Play();
        while(timeElapsed < lerpDuration)
        {
            musicAudio.volume = Mathf.Lerp(0, 1, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        musicAudio.volume = 1;
    }

    public IEnumerator FadeOutMusic()
    {
        float timeElapsed = 0;
        float lerpDuration = 2.0f;
        while (timeElapsed < lerpDuration)
        {
            musicAudio.volume = Mathf.Lerp(1, 0, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        musicAudio.volume = 0;
        musicAudio.clip = null;
    }

}

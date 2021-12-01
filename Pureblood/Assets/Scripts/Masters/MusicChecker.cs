using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChecker : MonoBehaviour
{
    AudioSource musicAudio;
    bool fadedMusic = false;
    // Start is called before the first frame update
    void Start()
    {
        musicAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.instance.playingMusic && !fadedMusic)
        {
            fadedMusic = true;
            StartCoroutine("FadeOutMusic");
        }
        else if(!Player.instance.playingMusic && fadedMusic)
        {
            StartCoroutine("FadeInMusic");
        }
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
        
    }
    public IEnumerator FadeInMusic()
    {
        float timeElapsed = 0;
        float lerpDuration = 2.0f;
        while (timeElapsed < lerpDuration)
        {
            musicAudio.volume = Mathf.Lerp(0, 1, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        musicAudio.volume = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SetVolume : MonoBehaviour
{
    
    public AudioMixer mixer;
    [SerializeField] TextMeshProUGUI sliderText;
    public Slider _slider;
    private float Value => _slider.value;
    // Start is called before the first frame update
  

    private void Start()
    {
        _slider.value = PlayerPrefs.GetFloat("volume", 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        sliderText.text = _slider.value.ToString("F2");
      
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("volume", sliderValue);
    }
    /*
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("volume", Value);
       
    }
    private void OnEnable()
    {
        _slider.value = PlayerPrefs.GetFloat("volume", 0.5f);
    }
    */
}

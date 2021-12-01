using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SetSFX : MonoBehaviour
{

    public AudioMixer mixer;
    [SerializeField] TextMeshProUGUI sliderText;
    public Slider _slider;
    private float Value => _slider.value;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat("SFX", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        sliderText.text = _slider.value.ToString("F2");
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFX", sliderValue);
    }

    //renable incase some shit blows or something or something
    /*
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("SFX", Value);

    }
    private void OnEnable()
    {
        _slider.value = PlayerPrefs.GetFloat("SFX", 0.5f);
    }
    */
}

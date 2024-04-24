using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class OptionUIHandlerDefinitive : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private Slider masterSlider, sfxSlider;
    [SerializeField] private TMP_Text masterLabel, sfxLabel;
    // Start is called before the first frame update
    void Start()
    {
        float vol = 0f;
        masterMixer.GetFloat("MasterVol", out vol);
        masterSlider.value = vol;
        masterMixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;
        masterLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //This sets Master volume
    public void SetMasterVol()
    {
        masterMixer.SetFloat("MasterVol", masterSlider.value);
        masterLabel.text = Mathf.RoundToInt(masterSlider.value+80).ToString();
        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }
    //This sets SFX volume
    public void SetSFXVol()
    {
        masterMixer.SetFloat("SFXVol", sfxSlider.value);
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value+80).ToString();
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}

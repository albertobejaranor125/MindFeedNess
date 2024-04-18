using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class OptionUIHandler : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private Slider masterSlider, sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //This goes to Main Menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    //This sets Master Volume
    public void SetMasterVol()
    {
        masterMixer.SetFloat("MasterVol", masterSlider.value);

        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }
    //This sets SFX volume
    public void SetSFXVol()
    {
        masterMixer.SetFloat("SFXVol", sfxSlider.value);

        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            masterMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
        }
        if (PlayerPrefs.HasKey("SFXVol"))
        {
            masterMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//This script is for adjusing the voulume of audio sources of the application with the music slider value.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeChanger: MonoBehaviour
{  
    private AudioSource audioSrc;                               // Reference to Audio Source component    
    private static float musicVolume;                           // Music volume variable that will be modified by dragging slider knob
    public Slider slider;
    
    void Start()                                                // Use this for initialization
    {       
        audioSrc = GetComponent<AudioSource>();                 // Assign Audio Source component to control it   
        musicVolume = PlayerPrefs.GetFloat("Volume");
    }
    
    void Update()                                               // Update is called once per frame
    {       
        audioSrc.volume = musicVolume;                          // Setting volume option of Audio Source to be equal to musicVolume
    }
     
    public void SetVolume(float vol)                            // Method that is called by slider game object
    {                                                           // This method takes vol value passed by slider and sets it as musicValue
        musicVolume = vol;
        PlayerPrefs.SetFloat("Volume",vol);
    }

}

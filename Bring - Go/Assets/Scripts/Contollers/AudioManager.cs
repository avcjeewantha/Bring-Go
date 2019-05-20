//This script is for managing the volume of audio sources in second scene.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audsrc;

    void Start()
    {
        audsrc = GetComponent<AudioSource>();            //get the audio source component of individual object.
        audsrc.volume = PlayerPrefs.GetFloat("Volume");   //change the volume of audio source according to the value of music slider.
    }

}
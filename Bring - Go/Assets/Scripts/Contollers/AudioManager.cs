using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audsrc;

    void Start()
    {
        audsrc = GetComponent<AudioSource>();
        audsrc.volume = PlayerPrefs.GetFloat("Volume");
    }

}

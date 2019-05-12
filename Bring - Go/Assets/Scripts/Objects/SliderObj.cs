//This script is for getting the slider value to the previous value (At the last time game played).

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderObj : MonoBehaviour
{
    public Slider slider;
            
    void Start()                                     // Start is called before the first frame update
    {
        if (PlayerPrefs.HasKey("Volume"))           //If there is a saved slider value in a device's registry, set the slider value as it is.
        {
            slider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            PlayerPrefs.SetFloat("Volume", 1);
            slider.value = 1f;
        }      
    }

}

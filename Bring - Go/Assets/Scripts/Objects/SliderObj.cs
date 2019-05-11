using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderObj : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
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

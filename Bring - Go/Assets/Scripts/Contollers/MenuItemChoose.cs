//This script is for evaluate the game when icons which are in shop panel are clicked.
//For icons individually.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemChoose : MonoBehaviour
{   
    
    void Start()        // Start is called before the first frame update
    {
        var button = transform.GetComponent<Button>();         //When the icon is clicked, evaluate method is called.
        button.onClick.AddListener(delegate () {
            TaskManager.evaluate(transform.GetComponent<Image>().sprite);
        });
    }

}

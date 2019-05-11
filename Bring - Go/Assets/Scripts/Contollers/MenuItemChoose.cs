using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuItemChoose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        var button = transform.GetComponent<Button>();
        button.onClick.AddListener(delegate () {
            TaskManager.evaluate(transform.GetComponent<Image>().sprite);
        });
    }

}

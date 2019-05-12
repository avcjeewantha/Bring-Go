//This script is for appearing the enter button of the Fruits shop.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FShop : MonoBehaviour {

    [SerializeField]
    private Button FShopEnterBtn = null;

    void Start ()                                                   // Start is called before the first frame update
    {
        FShopEnterBtn.gameObject.SetActive (false);
    }

    private void OnTriggerEnter2D (Collider2D collision)            //When the player object collide with the shop, the button appears.
    {          
        if (collision.gameObject.name.Equals ("PlayerObject")) {
            this.FShopEnterBtn.gameObject.SetActive (true);
        }
    }

    private void OnTriggerExit2D (Collider2D collision)             //When the player object went out from the shop, the button disappears.
    {           
        if (collision.gameObject.name.Equals ("PlayerObject")) {
            this.FShopEnterBtn.gameObject.SetActive (false);
        }
    }

}
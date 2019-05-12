using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script is for appearing the enter button of the clothes shop.

using UnityEngine.UI;

public class CShop : MonoBehaviour {

    [SerializeField]
    private Button CShopEnterBtn = null;

    void Start ()                                               // Start is called before the first frame update
    {
        CShopEnterBtn.gameObject.SetActive (false);
    }

    private void OnTriggerEnter2D (Collider2D collision) {      //When the player object collide with the shop, the button appears.
        if (collision.gameObject.name.Equals ("PlayerObject")) {
            this.CShopEnterBtn.gameObject.SetActive (true);
        }
    }

    private void OnTriggerExit2D (Collider2D collision) {       //When the player object went out from the shop, the button disappears.
        if (collision.gameObject.name.Equals ("PlayerObject")) {
            this.CShopEnterBtn.gameObject.SetActive (false);
        }
    }

}
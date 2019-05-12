//This script is for appearing the enter button of the Vegetable shop.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VShop : MonoBehaviour {

    [SerializeField]
    private Button VShopEnterBtn = null;

    void Start ()                                                       // Start is called before the first frame update
    {
        VShopEnterBtn.gameObject.SetActive (false);
    }

    private void OnTriggerEnter2D (Collider2D collision)                //When the player object collide with the shop, the button appears.
    {
        if (collision.gameObject.name.Equals ("PlayerObject")) {
            this.VShopEnterBtn.gameObject.SetActive (true);
        }
    }

    private void OnTriggerExit2D (Collider2D collision)                 //When the player object went out from the shop, the button disappears.
    {
        if (collision.gameObject.name.Equals ("PlayerObject")) {
            this.VShopEnterBtn.gameObject.SetActive (false);
        }
    }

}
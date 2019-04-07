using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FShop : MonoBehaviour {

    [SerializeField]
    private Button FShopEnterBtn = null;

    void Start () // Start is called before the first frame update
    {
        FShopEnterBtn.gameObject.SetActive (false);
    }

    void Update () // Update is called once per frame
    {
        //FShopEnterBtn.onClick (pickup);
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.name.Equals ("PlayerObject")) {
            this.FShopEnterBtn.gameObject.SetActive (true);
        }
    }

    private void OnTriggerExit2D (Collider2D collision) {
        if (collision.gameObject.name.Equals ("PlayerObject")) {
            this.FShopEnterBtn.gameObject.SetActive (false);
        }
    }

    public void pickup(){

    }

}
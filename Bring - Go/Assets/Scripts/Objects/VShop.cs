using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VShop : MonoBehaviour {

    [SerializeField]
    private Button VShopEnterBtn = null;

    void Start () // Start is called before the first frame update
    {
        VShopEnterBtn.gameObject.SetActive (false);
    }

    void Update () // Update is called once per frame
    {
        //VShopEnterBtn.onClick (pickup);
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.name.Equals ("PlayerObject")) {
            this.VShopEnterBtn.gameObject.SetActive (true);
        }
    }

    private void OnTriggerExit2D (Collider2D collision) {
        if (collision.gameObject.name.Equals ("PlayerObject")) {
            this.VShopEnterBtn.gameObject.SetActive (false);
        }
    }

    public void pickup () {

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CShop : MonoBehaviour {

    [SerializeField]
    private Button CShopEnterBtn = null;

    void Start () // Start is called before the first frame update
    {
        CShopEnterBtn.gameObject.SetActive (false);
    }

    void Update () // Update is called once per frame
    {
        //CShopEnterBtn.onClick (pickup);
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.name.Equals ("PlayerObject")) {
            this.CShopEnterBtn.gameObject.SetActive (true);
        }
    }

    private void OnTriggerExit2D (Collider2D collision) {
        if (collision.gameObject.name.Equals ("PlayerObject")) {
            this.CShopEnterBtn.gameObject.SetActive (false);
        }
    }

    public void pickup () {

    }

}
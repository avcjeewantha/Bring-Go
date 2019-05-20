using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTester : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CShop")
        {
            Debug.Log(collision.gameObject.tag + " Collide - Test Success");
        }
        else if (collision.gameObject.tag == "VShop")
        {
            Debug.Log(collision.gameObject.tag + " Collide - Test success");
        }
        else if (collision.gameObject.tag == "FShop")
        {
            Debug.Log(collision.gameObject.tag + " Collide - Test success");
        }
        else if (collision.gameObject.tag == "Canvas")
        {
            Debug.Log(collision.gameObject.tag + " Collide - Test success");
        }
    }

    void Update()
    {
        float x = Input.acceleration.x;
        float y = Input.acceleration.y;
        if (x < -0.2)
        {
            Debug.Log("Should move Left - testing...");
        }
        else if (x > 0.2)
        {
            Debug.Log("Should move Right - testing...");
        }
        else if (y < -0.2)
        {
            Debug.Log("Should move Down - testing...");
        }
        else if (y > 0.2)
        {
            Debug.Log("Should move Up - testing...");
        }
        else
        {
            Debug.Log("should wait - testing...");
        }
    }
}

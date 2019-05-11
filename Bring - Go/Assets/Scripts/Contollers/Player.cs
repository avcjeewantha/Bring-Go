using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // float horizontal = 50f;
    // float vertical = 50f;
    // float y = 50f;

    // void Start()     // Start is called before the first frame update
    // {
        
    // }

    // void Update()     // Update is called once per frame
    // {
    //     GetComponent<Rigidbody>().velocity = new Vector3(horizontal, vertical, y);
    // }

    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    //private bool didItPlay = false;

    void Start(){
        this.rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        //Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //moveVelocity = moveInput.normalized * speed;
        //transform.Translate(Input.acceleration.x * 10, Input.acceleration.y *10 , 0);

        float x = Input.acceleration.x;
        float y = Input.acceleration.y;
        if (x < -0.2)
        {
            moveLeft();
            GetComponent<AudioSource>().Play();
        }
        else if (x > 0.2)
        {
            moveRight();
            GetComponent<AudioSource>().Play();
        }
        else if (y < -0.2)
        {
            moveDown();
            GetComponent<AudioSource>().Play();
        }
        else if (y > 0.2)
        {
            moveUp();
            GetComponent<AudioSource>().Play();
        }
        else
        {
            Vector2 moveInput = new Vector2(0, 0);
            moveVelocity = moveInput.normalized * 0;

        }
    }

    void moveLeft()
    {
        Vector2 moveInput = new Vector2(-1, 0);
        moveVelocity = moveInput.normalized * speed;
    }

    void moveRight()
    {
        Vector2 moveInput = new Vector2(1, 0);
        moveVelocity = moveInput.normalized * speed;
    }

    void moveDown()
    {
        Vector2 moveInput = new Vector2(0, -1);
        moveVelocity = moveInput.normalized * speed;
    }

    void moveUp()
    {
        Vector2 moveInput = new Vector2(0, 1);
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        rb.freezeRotation = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
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

    void Start(){
        this.rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

}

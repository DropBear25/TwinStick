using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D myBody;

    public float speed;

    private Vector2 moveVelocity;


    public void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement(); 
        
    }

     void Movement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        myBody.MovePosition(myBody.position + moveVelocity * Time.fixedDeltaTime);
    }
}

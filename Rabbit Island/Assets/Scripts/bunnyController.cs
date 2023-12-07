using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunnyController : MonoBehaviour
{
    public float forcaPulo;
    private Rigidbody2D playerRb;
    private bool grounded;
    public Transform groundCheck;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f);
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Jump") && grounded == true){
           playerRb.AddForce(new Vector2(0, forcaPulo));     
        }
        
    }
}

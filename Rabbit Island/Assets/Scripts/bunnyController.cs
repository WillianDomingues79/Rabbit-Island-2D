using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunnyController : MonoBehaviour
{
    public float forcaPulo;
    private Rigidbody2D playerRb;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Jump")){
           playerRb.AddForce(new Vector2(0, forcaPulo));     
        }
        
    }
}

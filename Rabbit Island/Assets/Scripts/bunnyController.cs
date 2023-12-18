using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunnyController : MonoBehaviour
{
    private gameController _GameController;
    public float forcaPulo;
    private Rigidbody2D playerRb;
    private bool grounded;
    public Transform groundCheck;
    
    void Start()
    {
        _GameController = FindObjectOfType(typeof(gameController)) as gameController;
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

    void OnTriggerEnter2D(Collider2D col){
        switch(col.gameObject.tag){
            case "coletavel":
            _GameController.pontuar(10);
            Destroy(col.gameObject);
            break;

            case "obstaculo":
            _GameController.mudarCena("gameOver");
            break;
        }
    }
}

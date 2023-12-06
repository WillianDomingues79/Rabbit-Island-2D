using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private gameController _GameController;
    private Rigidbody2D playerRb;
    

    // Start is called before the first frame update
    void Start()
    {
        _GameController = FindObjectOfType(typeof(gameController)) as gameController;

        QualitySettings.vSyncCount = 1;
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movimentacao entre eixos
        float horizontal = Input.GetAxisRaw("Horizontal");//Usa eixo HORIZONTAL, CONTROLE: SETAS <- ->
        float vertical = Input.GetAxisRaw("Vertical");

        //Limitacao Cenario
        float posY = transform.position.y;
        float posX = transform.position.x;


        playerRb.velocity = new Vector2 (horizontal * _GameController.velocidade, vertical * _GameController.velocidade);//PARADO = 0, ANDANDO PRA FRENTE 2*1 = 2, ANDANDO PARA TRAS 2*(-2)=    -2


        //Limitacao Cenario
        //Verificar Limite X
        if (transform.position.x > _GameController.limiteMaxX)
        {
            posX = _GameController.limiteMaxX;
        }
        else if (transform.position.x < _GameController.limiteMinX)
        {
            posX = _GameController.limiteMinX;
        }


        //Verificar Limite Y
        if (transform.position.y > _GameController.limiteMaxY )
        {
            posY = _GameController.limiteMaxY;
        }
        else if(transform.position.y < _GameController.limiteMinY ) 
        { 
            posY = _GameController.limiteMinY; 
        }

        transform.position = new Vector3(posX, posY, 0);
    }

    void OnTriggerEnter2D() {
        /*Debug.LogError("Game-Over");
        //Application.Quit();
        Time.timeScale = 0;
        print("Bateu");*/
        _GameController.mudarCena("gameOver");
    }
}

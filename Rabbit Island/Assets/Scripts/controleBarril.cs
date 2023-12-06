using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleBarril : MonoBehaviour
{
    private gameController _GameController;
    private Rigidbody2D barrilRb;

    private bool pontuado;
    void Start()
    {
        _GameController = FindAnyObjectByType(typeof(gameController)) as gameController;

        barrilRb = GetComponent<Rigidbody2D>();
        barrilRb.velocity = new Vector2(_GameController.velocidadeObjeto, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < _GameController.distanciaDestruir){
            Destroy(this.gameObject);
        }
    }

    void LateUpdate(){
        if(pontuado == false && transform.position.x < _GameController.posXPLayer){
            pontuado = true;
            print("Ponto");
            _GameController.pontuar(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    private playerController _playerController;

    [Header("Config. Personagem")]
    public float velocidade;

    //Limitacao Cenario
    public float limiteMaxY;
    public float limiteMinY;
    public float limiteMaxX;
    public float limiteMinX;

    [Header("Config. Objetos")]
    public float velocidadeObjeto;
    public float distanciaDestruir;

    public float tamanhoPonte;
    public GameObject pontePrefab;

    [Header("Config. Barril")]
    public float posYTop;
    public float posYDown;
    public int orderTop;
    public int orderDown;
    public GameObject barrilPrefab;
    public float tempoRespawn;

    [Header("Globals")]
    public float posXPLayer;
    public int score;
    public Text txtScore;
    
    [Header("FX Sound")]
    public AudioSource fxSource;
    public AudioClip fxPontos;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = FindObjectOfType(typeof(playerController)) as playerController;
        StartCoroutine("spawnBarril");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        posXPLayer = _playerController.transform.position.x;
    }

    IEnumerator spawnBarril(){
        yield return new WaitForSeconds(tempoRespawn);
        float posY = 0;
        int order = 0;

        int rand = Random.Range(0,100);
        if(rand < 50){
            posY = posYTop;
            order = orderTop;
        } else {
            posY = posYDown;
            order = orderDown;
        }

        GameObject temp = Instantiate(barrilPrefab);
        temp.transform.position = new Vector3(temp.transform.position.x, posY, 0);//Muda o eixo X
        temp.GetComponent<SpriteRenderer>().sortingOrder = order; //Muda a ordem do Layer

        StartCoroutine("spawnBarril");
    }

    public void pontuar(int qtdPontos){
        score += qtdPontos;
        txtScore.text = "Pontos: " + score.ToString();
        fxSource.PlayOneShot(fxPontos);
    }

    public void mudarCena(string cenaDestino){
        SceneManager.LoadScene(cenaDestino);
    }
}

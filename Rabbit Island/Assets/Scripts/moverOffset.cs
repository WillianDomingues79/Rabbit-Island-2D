using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverOffset : MonoBehaviour
{
    private Renderer meshRenderer;
    private Material currentMaterial;

    public float incrementoOffset;
    public float speed;

    public string sortingLayer;
    public int orderInLayer;

    private float offSet;//Faz a rotação da nuvem

    // Start is called before the first frame update
    void Start()
    {
        //Altera a ordem das texturas na cena
        meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.sortingLayerName = sortingLayer;
        meshRenderer.sortingOrder = orderInLayer;

        currentMaterial = meshRenderer.material;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Faz a rotação da nuvem
        offSet += incrementoOffset;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offSet * speed, 0));
    }
}

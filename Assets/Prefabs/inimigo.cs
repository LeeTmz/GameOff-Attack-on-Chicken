using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class inimigo : MonoBehaviour {

    public Transform player;
    public GameObject bala;
    public float velocidade;

    float tempo;



    private void Start()
    {

        

    }
    private void Update()
     {

        float distancia = Vector2.Distance(transform.position, player.position);
        

            if(distancia > 1 && distancia < 10)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, velocidade * Time.deltaTime);

        }
     }
   

}



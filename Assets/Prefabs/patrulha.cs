using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrulha : MonoBehaviour
{
    public Transform[] posicao;//posições dos locais que o inimigo ficará patrulhando
    public float velocidade;//velocidade do inimigo
    public float tempoEspera;//tempo que o inimigo esperará para andar novamente
    int tempoRandomica;//local randomico que o inimigo irá
    float tempo;

    public SpriteRenderer renderer;//take flip

    

   
    void Start()
    {
        tempoRandomica = Random.Range(0, posicao.Length);//posição randomica que o inimigo irá, de acordo com o tamanho do vetor
        tempo = tempoEspera;//tempo que esperará

        renderer = GetComponent<SpriteRenderer>();
         renderer.flipX = false;
       
       
   }   
    
    
    // Update is called once per frame
    void Update()
    {

            //float distancia = Vector2.Distance(transform.position, player.position);
        transform.position = Vector2.MoveTowards(transform.position, posicao[tempoRandomica].position, velocidade * Time.deltaTime);//inimigo pegando posiçaõ

        float distancia = Vector2.Distance(transform.position, posicao[tempoRandomica].position);//distancia randomica do inimigo

        if(distancia <= .2f)//se a distancia do inimigo for menor que 2
        {
            
            if (tempo <= 0)//se o tempo for menos que zero
            {
                tempoRandomica = Random.Range(0, posicao.Length);//pegarará a posição randomica de acordo com o tamanho do vetor
                tempo = tempoEspera;
                 renderer.flipX = true;
                
            }


            else
                tempo -= Time.deltaTime;//senao o tempo diminuirá
                
        }
    }
}

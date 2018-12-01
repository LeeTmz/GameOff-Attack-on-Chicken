using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour {

    private bool eLadoDireito;
    [SerializeField]
    private float velocidade;
    private Animator animator;

    private float tempoIdle;
    [SerializeField]
    private float duracaoIdle;

    private float tempoPatrulhar;
    [SerializeField]
    private float duracaoPatrulhar;

    private float tempoAtacar;
    [SerializeField]
    private float duracaoAtacar;

    private bool estaPatrulhando;
    private bool atacar;

    public float playerDistancia;
    public float ataqueDistancia;
    public GameObject player;

	void Start () {
        animator = GetComponent<Animator>();
        eLadoDireito = true;
        estaPatrulhando = false;
        atacar = false;

	}
	
	// Update is called once per frame
	void Update () {

        MudarEstado();
        playerDistancia = transform.position.x - player.transform.position.x;
        if(Mathf.Abs(playerDistancia) < ataqueDistancia)
        {
            atacar = true;
            estaPatrulhando = false;
            idle();
            Atacar();
        }
        else
        {
            MudarEstado();
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "limite")
        {
            MudarPo();
        }
    }

    private void mover()
    {
        transform.Translate(pegarDirecao() * (velocidade * Time.deltaTime));
        animator.SetBool("walk", true);
    }

    //metodos

    private Vector2 pegarDirecao()
    {
        return eLadoDireito ? Vector2.right : Vector2.left;
    }
    
    private void MudarPo()
    {
        eLadoDireito = !eLadoDireito;
        this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }


    //metodos outros
    void idle()
    {
        tempoIdle += Time.deltaTime;
        if(tempoIdle <= duracaoIdle)
        {
            animator.SetBool("walk", estaPatrulhando);
            tempoPatrulhar = 0;
        }
        else
        {
            estaPatrulhando = true;
        }
    }

    void Patrulha()
    {
        tempoIdle += Time.deltaTime;
        if (tempoPatrulhar <= duracaoPatrulhar)
        {
            animator.SetBool("walk", estaPatrulhando);
            mover();
            tempoPatrulhar = 0;
        }
        else
        {
            estaPatrulhando = false;
        }
    }

    void MudarEstado()
    {
        if(!atacar)
        {
            if(!estaPatrulhando)
            {
                idle();
            }
            else
            {
                Patrulha();
            }
        }
    }

    void Atacar()
    {
        if(playerDistancia < 0 && !eLadoDireito || playerDistancia > 0 && eLadoDireito)
        {
            MudarPo();
        }
        if (atacar)
        {
            tempoAtacar += Time.deltaTime;
            if(tempoAtacar >= duracaoAtacar)
            {
                tempoAtacar = 0;
            }
        }
    }

    public void ResetarAtacar()
    {
        atacar = false;
    }

    void OnTriggerEnter2D(Collider col)
     {
         if (col.CompareTag("Player")){
             Destroy(gameObject);
         }
     }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Deu");
            Destroy(other.gameObject);
        }
    }
}

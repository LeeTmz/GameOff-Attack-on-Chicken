using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VidaPlayer : MonoBehaviour {

    public int Vida;

    public TextMeshProUGUI Voce;
    public TextMeshProUGUI Deseja;
    public TextMeshProUGUI Sim;
    public TextMeshProUGUI Nao;

    public Image cora1;
    public Image cora2;
    public Image cora3;

    public Image telaMorte;

    // Use this for initialization
    void Start () {

        telaMorte.enabled = false;
        Voce.enabled = false;
        Deseja.enabled = false;
        Sim.enabled = false;
        Nao.enabled = false;
        
        cora1.enabled = true;
        cora2.enabled = true;
        cora3.enabled = true;


    }
	
	// Update is called once per frame
	void Update () {
       
        if(Vida == 2)
        {
            cora3.enabled = false;
        }
        if (Vida == 1)
        {
            cora2.enabled = false;
        }
        if (Vida == 0)
        {

            

            cora1.enabled = false;

            telaMorte.enabled = true;
            Voce.enabled = true;
            Deseja.enabled = true;
            Sim.enabled = true;
            Nao.enabled = true;

           


        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Inimigo"))
        {
            
            
            Vida --;

        }



    }





}

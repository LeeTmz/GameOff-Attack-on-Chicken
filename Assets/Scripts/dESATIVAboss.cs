using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dESATIVAboss : MonoBehaviour {


    public GameObject boss;

    public Image TelaVitoria;
    public TextMeshProUGUI Parabens;
    public TextMeshProUGUI JogarNovamente;

    // Use this for initialization
    void Start () {

        TelaVitoria.enabled = false;
        Parabens.enabled = false;
        JogarNovamente.enabled = false;



	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag.Equals("Player"))
        {

            boss.SetActive(false);

            TelaVitoria.enabled = true;
            Parabens.enabled = true;
            JogarNovamente.enabled = true;

        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarBoss : MonoBehaviour {

    public GameObject boss;
    public GameObject musicafinal;
    public GameObject musicainicial;


    // Use this for initialization
    void Start () {
        musicafinal.SetActive(false);
        boss.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag.Equals("Player"))
        {
            musicainicial.SetActive(false);
            musicafinal.SetActive(true);
            boss.SetActive(true);

        }


    }

}

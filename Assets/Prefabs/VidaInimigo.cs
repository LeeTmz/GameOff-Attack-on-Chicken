using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour {
    public int vidainimigo;
    public GameObject galinha;
    public GameObject blood;
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(vidainimigo == 0)
        {


            gameObject.SetActive(false);
            Instantiate(blood, transform.position, Quaternion.identity);
            

        }
        

	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("bala"))
        {
            
            vidainimigo --;

        }



    }
}

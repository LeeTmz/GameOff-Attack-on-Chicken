using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public float velocidade;
    public Rigidbody2D rb;
    public int vidaBoss;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        rb.velocity = transform.right * velocidade;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("bala"))
        {
            Debug.Log("Colidiu");
            vidaBoss--;

        }



    }

}

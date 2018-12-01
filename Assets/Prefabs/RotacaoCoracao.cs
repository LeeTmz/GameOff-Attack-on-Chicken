using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoCoracao : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Rotate(new Vector3(0, (25 * Time.deltaTime), 0));
	}
}

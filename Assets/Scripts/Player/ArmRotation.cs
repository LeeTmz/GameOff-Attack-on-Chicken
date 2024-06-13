using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

	public int rotationOffset = 90;
	Vector3 difference;

	public SpriteRenderer player;
	// Update is called once per frame
	void Update () {
		
	    difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();		

		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;	// find the angle in degrees
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);

		if(rotZ > 90 || rotZ < -90) 
		{			
			transform.localScale = new Vector3(1, -1, 1);
		}
		else
		{
			transform.localScale = new Vector3(1, 1, 1);
		}

		player.flipX = difference.x < 0;
	}

	
}

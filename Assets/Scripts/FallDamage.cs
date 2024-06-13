using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
	private PlayerHealth playerHealth;
	//[SerializeField]private SafeGroundSaver safeGroundSaver;
	private SafeGroundCheckPointSave safeGroundCheckPointSave;

	private void Start()
	{
		safeGroundCheckPointSave = GameObject.FindGameObjectWithTag("Player").GetComponent<SafeGroundCheckPointSave>();
		//safeGroundSaver = GameObject.FindGameObjectWithTag("Player").GetComponent<SafeGroundSaver>();
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player")) 
		{
			playerHealth = col.gameObject.GetComponent<PlayerHealth>();

			playerHealth.Damage(1f);

			//safeGroundSaver.WarpPlayerToSafeGround();
			safeGroundCheckPointSave.WarpPlayerToSafeGround();
		}
	}
}

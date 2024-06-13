using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAction : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			Debug.Log("Colidiu para disparar a action");
			GameEvents.TestActionNormal?.Invoke();
			GameEvents.TestActionGold?.Invoke(13.75f);
		}
	}
	
}

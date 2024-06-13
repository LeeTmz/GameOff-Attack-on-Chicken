using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeGroundCheckPointSave : MonoBehaviour
{

	[SerializeField] private LayerMask whatIsCheckPoint;
	public Vector2 SafeGroundLocation { get; private set; } = Vector2.zero;


	private void Start()
	{
		SafeGroundLocation = transform.position;
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if((whatIsCheckPoint.value & (1 << col.gameObject.layer)) > 0) 
		{
			SafeGroundLocation = new Vector2(col.bounds.center.x, col.bounds.min.y);
		}
	}

	public void WarpPlayerToSafeGround() 
	{
		transform.position = SafeGroundLocation;
	}
}

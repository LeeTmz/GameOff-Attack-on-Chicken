using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	[SerializeField] private float extraheight = 0.25f;
	[SerializeField] private LayerMask whatIsGround;


	private RaycastHit2D groundHit;
	private Collider2D coll;

	private void Start()
	{
		coll = GetComponent<Collider2D>();
	}

	public bool IsGrounded() 
	{
		groundHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, extraheight, whatIsGround);

		if (groundHit.collider != null)
		{
			return true;
		}
		else 
		{
			return false;
		}
	}

}

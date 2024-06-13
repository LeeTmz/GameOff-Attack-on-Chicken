using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] private float moveSpeed = 7.5f;

	[Header("Jump")]
	[SerializeField] private float jumpForce = 5f;
	[SerializeField] private float jumpTime = .5f;

	[Header("GroundCheck")]
	[SerializeField] private float extraheight = 0.25f;
	[SerializeField] private LayerMask wahtIsGround;

	private Rigidbody2D rb;
	private Collider2D col;
	private Animator anim;

	private float moveInput;

	private bool isJumping;
	private bool isFalling;
	private float jumpTimeCounter;

	private RaycastHit2D groundHit;

	private Coroutine resetTriggerCoroutine;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<Collider2D>();
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		Move();
		Jump();
	}
	public void Move() 
	{
		moveInput = UserInput.Instance.moveInput.x;

		if(moveInput >0|| moveInput  <0) 
		{
			anim.SetBool("isWalking", true);
		}
		else 
		{
			anim.SetBool("isWalking", false);
		}



		rb.velocity = new Vector2 (moveInput * moveSpeed, rb.velocity.y);
	}
	public void Jump() 
	{
		if (UserInput.Instance.controls.Jumping.Jump.WasPressedThisFrame() && isGrounded()) 
		{
			isJumping = true;
			jumpTimeCounter = jumpTime;
			rb.velocity= new Vector2 (rb.velocity.x, jumpForce);

			anim.SetTrigger("jump");
		}

		if (UserInput.Instance.controls.Jumping.Jump.IsPressed())
		{
			if (jumpTimeCounter > 0 && isJumping)
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
			else if (jumpTimeCounter == 0) 
			{
				isFalling = true;
				isJumping = false;
			}
			else
			{
				isJumping = true;
			}
		}

		if (UserInput.Instance.controls.Jumping.Jump.WasReleasedThisFrame())
		{
			isJumping = false;
			isFalling= true;
		}

		if(!isJumping && CheckForLand()) 
		{
			anim.SetTrigger("land");
			resetTriggerCoroutine = StartCoroutine(Reset());
		}
	}
	private bool isGrounded() 
	{
		groundHit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, extraheight,wahtIsGround);

		if (groundHit.collider != null) return true;
		else return false;
	}
	private bool CheckForLand() 
	{
		if(isFalling) 
		{
			if(isGrounded()) 
			{
				isFalling = false;
				return true;
			}
			else return false;
		}
		else { return false; }
	}

	private IEnumerator Reset() 
	{
		yield return null;

		anim.ResetTrigger("land");
	}
}

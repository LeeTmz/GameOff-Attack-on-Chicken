using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour 
{

    [Header("Move config")]
    [SerializeField] private float speed;


	[Header("Jump config")]
	 private float maxHeight = 2;
	 private float jumpSpeed;
	 private float timeToPeak = 1f;

	 CharacterController controller;


	Vector2 xVelocity;
	Vector2 yVelocity;
	Vector2 finalVelocity;

	float gravity;

	private void Start()
	{
		controller = GetComponent<CharacterController>();

		//Gravity
		gravity = (2 * maxHeight) / Mathf.Pow(timeToPeak, 2);

		jumpSpeed = gravity * timeToPeak;
	}
	private void Update()
	{
		if (controller.isGrounded) yVelocity = Vector2.down;

		MovePlayer();
		Gravity();



		if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) 
		{
			JumpPlayer();
		}

		finalVelocity = xVelocity + yVelocity;

		controller.Move(finalVelocity * Time.deltaTime);
	}

	void MovePlayer() 
	{
		float xInput = Input.GetAxis("Horizontal");

		xVelocity = speed * xInput * Vector2.right;		
	}

	void Gravity() 
	{
		yVelocity += gravity * Time.deltaTime * Vector2.down;
	}
	void JumpPlayer() 
	{
		yVelocity = jumpSpeed * Vector2.up;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    private Rigidbody2D body;
    public float runSpeed = 10;
    public BoxCollider2D colisor;
    public LayerMask ground;
    public float jumpForce = 20;
    private Animator animator;
    private SpriteRenderer sprite;
    private float tempoIdle;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extrajumps;
    public int extraJampsValue;

    // Use this for initialization
    void Start () {
        extrajumps = extraJampsValue;

        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update() {

        GetForwardInput();
        GetJumpInput();


        if (isGrounded == true)
        {
            extrajumps = extraJampsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extrajumps > 0)
        {

            body.velocity = Vector2.up * jumpForce;
            extrajumps--;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && extrajumps == 0 && isGrounded == true)
        {
            body.velocity = Vector2.up * jumpForce;
        }



    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

       
    }


    private void GetForwardInput()
    {
        
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, body.velocity.y);
        

        animator.SetFloat("xSpeed", Mathf.Abs(body.velocity.x));
        if (!sprite.flipX && body.velocity.x < 0)
        {
            sprite.flipX = true;
        }
        else if(sprite.flipX && body.velocity.x > 0)
        {
            sprite.flipX = false;
        }
            
    }
    private void GetJumpInput()
    {

        if (Input.GetButtonDown("Jump"))
        {

            body.AddForce(Vector2.up * jumpForce);
           
            
        }
        
    }
    
}

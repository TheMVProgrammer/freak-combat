using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float moveForce = 10f; // Variable that we are going to use to move the player.

    public float jumpForce = 11f; // Variable that we are going to use to manage jump movement.
    
    private float movementX;

    private Rigidbody2D rb;

    private Collider2D Collider2D;

    private SpriteRenderer sr;

    private Animator animator;

    private readonly string WALK_ANIMATION = "Walk";

    private readonly string RUN_ANIMATION = "Run";

    private readonly string JUMP_ANIMATION = "Jump";

    private bool isGrounded;

    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        Collider2D = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboad();
        AnimatePlayer();
        PlayerJump();
        PlayerRun();
    }

    void PlayerMoveKeyboad()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += moveForce * Time.deltaTime * new Vector3(movementX, 0f, 0f);
    }
    void AnimatePlayer()
    {
        if (movementX > 0f)
        {
            // We are going to the right side
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
            Collider2D.offset = new Vector2(-1.386465f, Collider2D.offset.y);

        }
        else if (movementX < 0f)
        {
            // We are going to the left side
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
            Collider2D.offset = new Vector2(1.386465f, Collider2D.offset.y);
        }
        else
        {
            animator.SetBool(WALK_ANIMATION, false);
        }
    }    

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool(JUMP_ANIMATION, true);
        } 
    }

    void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool(RUN_ANIMATION, true);
            moveForce = 15f;

        } 
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool(RUN_ANIMATION, false);
            moveForce = 10f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            animator.SetBool(JUMP_ANIMATION, false);
        }
            
    }


} // class

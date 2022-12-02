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

    private readonly string JUMP_HIGH_ANIMATION = "JumpHigh";

    private bool isGrounded;

    private readonly string GROUND_TAG = "Ground";

    //private string ENEMY_TAG = "Enemy";

    // Attacks

    private readonly string ATTACK_ANIMATION = "Attack";

    private readonly string ATTACK_EXTRA_ANIMATION = "AttackExtra";

    private readonly string WALK_ATTACK_ANIMATION = "WalkAttack";

    private readonly string RUN_ATTACK_ANIMATION = "RunAttack";

    public Transform attackPoint;

    public float attackRange = 1f;

    public LayerMask enemyLayers;

    public int damageZ = 3;

    public int damageX = 6;

    //HealthBar and Damage

    public Canvas canvas;

    public int maxHealth;
    int currentHealth;

    public HealthBar healthBar;
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
        maxHealth = 250;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboad();
        AnimatePlayer();
        PlayerJump();
        PlayerRun();
        Attack();

        if (sr.flipX == true)
        {
            attackPoint.position = new Vector2(-0.98f + transform.position.x, attackPoint.position.y);
        }
        else if (sr.flipX == false)
        {
            attackPoint.position = new Vector2(0.98f + transform.position.x, attackPoint.position.y);
        }
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
            canvas.transform.position = new Vector2(transform.position.x - 1.03f, canvas.transform.position.y);
            Collider2D.offset = new Vector2(-1f, Collider2D.offset.y);

        }
        else if (movementX < 0f)
        {
            // We are going to the left side
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
            canvas.transform.position = new Vector2(transform.position.x + 0.68f, canvas.transform.position.y);
            Collider2D.offset = new Vector2(1f, Collider2D.offset.y);
        }
        else
        {
            animator.SetBool(WALK_ANIMATION, false);
        }
    }    

    void PlayerJump()
    {
        if (moveForce == 15f && Input.GetButtonDown("Jump") && isGrounded) //Run jump
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce * 1.35f), ForceMode2D.Impulse);
            animator.SetBool(JUMP_HIGH_ANIMATION, true);
        }
        else if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool(JUMP_ANIMATION, true);
        } else if (isGrounded == true)
        {
            animator.SetBool(JUMP_HIGH_ANIMATION, false);
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

    // Attack method
    void Attack()
    {
        // Attack 1

        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Play an attack animation

            animator.SetBool(ATTACK_ANIMATION, true);

            // Detect enemies in range of attack

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            // Damage enemies in range of attack

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(damageZ);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetBool(ATTACK_ANIMATION, false);
        }

        // Attack 2

        if (Input.GetKeyDown(KeyCode.X))
        {
            // Play an attack animation

            animator.SetBool(ATTACK_EXTRA_ANIMATION, true);

            // Detect enemies in range of attack

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            // Damage enemies in range of attack

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(damageX);
            }
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            animator.SetBool(ATTACK_EXTRA_ANIMATION, false);
        }

        // Walk Attack

        if (Input.GetKeyDown(KeyCode.Z) && (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < 0f))
        {
            // Play an attack animation

            animator.SetBool(ATTACK_ANIMATION, false);

            animator.SetBool(WALK_ATTACK_ANIMATION, true);

            // Detect enemies in range of attack

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            // Damage enemies in range of attack

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(damageZ);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetBool(WALK_ATTACK_ANIMATION, false);
        }

        // Run Attack

        if (Input.GetKeyDown(KeyCode.Z) && moveForce == 15f)
        {
            // Play an attack animation
            animator.SetBool(RUN_ATTACK_ANIMATION, true);

            // Detect enemies in range of attack

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            // Damage enemies in range of attack

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(damageZ);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetBool(RUN_ATTACK_ANIMATION, false);
        }
              
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // Play hurt animation

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        // Die animation

        animator.SetBool("Isdead", true);
        canvas.enabled = false;
        rb.isKinematic = true;
        //Disable the player

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }


} // class

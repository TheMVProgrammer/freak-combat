using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D body;
    public Transform player;
    public bool isFlipped = false;

    public Animator animator;
    public Canvas canvas;

    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    /*Sounds*/

    AudioSource OrkPain;


    private void Awake()
    {    
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }
        

    // Start is called before the first frame update
    void Start()
    {
        OrkPain = GameObject.Find("OrkPain").GetComponent<AudioSource>();
        maxHealth = 250;
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);        
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // Play hurt animation

        animator.SetTrigger("Hurt");

        OrkPain.Play();

        if (currentHealth <= maxHealth * 0.35f)
        {
            transform.localScale = new Vector2(1.3f, 1.3f);
            transform.position = new Vector2(transform.position.x, transform.position.y);
            spriteRenderer.color = Color.red;
        }

        if(currentHealth <= 0)
        {
            transform.localScale = new Vector2(1f, 1f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 1f);
            spriteRenderer.color = Color.white;
            Die();
        }

    }
    void Die()
    {
        // Die animation

        body.isKinematic = true;
        animator.SetBool("Isdead", true);
        canvas.enabled = false;

        //Disable the enemy

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;       
        
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

} // class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;

    public Animator animator;
    public Canvas canvas;

    public int maxHealth = 100;
    int currentHealth;

    public HealthBar healthBar;
    private void Awake()
    {    
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);        
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // Play hurt animation

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        // Die animation

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

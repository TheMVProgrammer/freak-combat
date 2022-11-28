using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightCombat : MonoBehaviour
{
    private Animator animator;

    private readonly string ATTACK_ANIMATION = "Attack";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        // Play an attack animation
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool(ATTACK_ANIMATION, true);
        }  
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            animator.SetBool(ATTACK_ANIMATION, false);
        }



        // Detect enemies in range of attack
        // Damage enemies in range of attack
    }
} // class


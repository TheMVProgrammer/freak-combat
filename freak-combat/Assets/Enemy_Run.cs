using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Run : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D body;
    Enemy enemy;
    public float speed = 2.5f;
    public float attackRange = 5f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        body = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.currentHealth > 0)
        {
            enemy.LookAtPlayer();

            Vector2 target = new(player.position.x, body.position.y);
            Vector2 newPos = Vector2.MoveTowards(body.position, target, speed * Time.fixedDeltaTime);
            body.MovePosition(newPos);
        }       

        //Agregar una condición para que deje de atacar cuando currentHealth sea 0
        if(Vector2.Distance(player.position, body.position) <= attackRange)
        {
            animator.SetTrigger("Attack");

            if (enemy.currentHealth <= 0f) 
            {
                animator.ResetTrigger("Attack");
            }

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}

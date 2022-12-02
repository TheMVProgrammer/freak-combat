using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollWeapon : MonoBehaviour
{
	public Enemy enemy;
    public int attackDamage = 10;
    public int enragedAttackDamage = 30;

    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			if(enemy.currentHealth <= 35f)
            {
				colInfo.GetComponent<Knight>().TakeDamage(enragedAttackDamage);
			}
			else
            {
				colInfo.GetComponent<Knight>().TakeDamage(attackDamage);
			}			
		}
	}
	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}

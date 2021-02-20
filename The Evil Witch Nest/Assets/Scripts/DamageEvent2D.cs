using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEvent2D : MonoBehaviour
{
    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private float attackRange = 0.5f;

    [SerializeField]
    private LayerMask damageableLayers;

    public int damageRate;


    public void AttackEvent()
    {
        Collider2D[] damageableObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, damageableLayers);

        foreach (Collider2D damageableObject in damageableObjects)
            damageableObject.GetComponent<DamageableBeing2D>().ReceiveDamage(damageRate);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public Transform getAttackPoint()
    {
        return attackPoint;
    }

    public float getAttackRange()
    {
        return attackRange;
    }
}

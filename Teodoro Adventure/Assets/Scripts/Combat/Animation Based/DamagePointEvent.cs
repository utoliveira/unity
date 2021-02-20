using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePointEvent : MonoBehaviour
{

    [SerializeField]
    private LayerMask damageableLayers;

    [SerializeField]
    private Transform damagePoint;

    [SerializeField]
    private float damageRange;

    [SerializeField]
    private int damageRate;

    public void Hit()
    {
        Collider2D[] damageableElements = Physics2D.OverlapCircleAll(damagePoint.position, damageRange, damageableLayers);
        foreach (Collider2D damageable in damageableElements)
            damageable.GetComponent<DamageableBeing>().ReceiveDamage(damageRate);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePoint.position, damageRange);
    }

    public Vector2 GetAttackPosition()
    {
        return damagePoint.position;
    }

    public float GetAttackRange()
    {
        return damageRange;
    }
}

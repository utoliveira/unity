using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController2D : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    [SerializeField]
    private float attackRate = 1f;

    private float nextAttackTime;

    [SerializeField]
    private DamageEvent2D damageEvent;

    /*This Event must be called by the Input Controller*/
    public void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            animator.SetTrigger("attack");
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    public void SetAttackRate(float attackRate)
    {
        this.attackRate = attackRate;
    }

    public float getMinimalDistanceToAttack()
    {
        return Mathf.Abs(damageEvent.getAttackPoint().localPosition.x + damageEvent.getAttackRange());
    }
}

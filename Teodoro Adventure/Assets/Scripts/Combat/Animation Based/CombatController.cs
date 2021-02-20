using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatController : MonoBehaviour
{   
    [SerializeField]
    protected float attackRate = 1f;

    private float nextAttackTime;

    public abstract void OnAttack();
    public abstract float GetMinimalDistanceToAttack();
    public void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            OnAttack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

}

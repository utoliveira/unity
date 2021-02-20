using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatControllerAnimBased : CombatController
{
    [SerializeField]
    private Animator animator;


    [SerializeField]
    private DamagePointEvent damagePoint;

    public override void OnAttack()
    {
        animator.SetTrigger(AnimatorConst.attack);
    }

    public override float GetMinimalDistanceToAttack()
    {
        return Mathf.Abs(damagePoint.GetAttackPosition().x + damagePoint.GetAttackRange());
    }
}

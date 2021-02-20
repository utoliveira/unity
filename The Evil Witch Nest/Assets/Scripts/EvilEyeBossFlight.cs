using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEyeBossFlight : StateMachineBehaviour
{
    [SerializeField]
    [Range(0.01f, 1f)]
    private float lifePercentToEnrage;

    DamageableBeing2D damageableBeing;
    

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        damageableBeing = animator.GetComponent<DamageableBeing2D>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(damageableBeing.getCurrentHealth() < damageableBeing.getMaxHealth() * 0.5f)
        {
            animator.SetTrigger("enrage");
        }
    }
}

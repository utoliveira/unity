using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnrage : StateMachineBehaviour
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<DamageableBeing2D>().setInvencible();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<DamageableBeing2D>().removeInvencible();
        animator.SetBool("isEnraged", true);

    }
}

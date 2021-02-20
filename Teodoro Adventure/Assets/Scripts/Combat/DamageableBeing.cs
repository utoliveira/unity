using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableBeing : MonoBehaviour
{

    [SerializeField]
    private int maxHealth;

    private int health;

    [SerializeField]
    private Animator animator;

    [Space]
    [Header("Events")]
    [SerializeField]
    private UnityEvent onDie;

    private void Awake()
    {
        health = maxHealth;
    }


    public void ReceiveDamage(int damageRate)
    {
        if (health - damageRate < 0)
            health = 0;
        else
            health -= damageRate;

        if (health == 0)
            Die();
        else
            animator.SetTrigger(AnimatorConst.receiveDamage);
    }

    private void Die()
    {
        animator.SetTrigger(AnimatorConst.die);
        onDie.Invoke();
    }

    public bool IsAlive()
    {
        return health > 0;
    }
}

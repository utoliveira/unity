using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAI : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private CharacterController2D characterController;

    [SerializeField]
    private CombatController combatController;
    
    [SerializeField]
    private LayerMask enemiesLayer;

    [SerializeField]
    private float rangeOfView;

    private DamageableBeing enemyToAttack;

    private float minimalDistanceToAttack;

    private void Start()
    {
        minimalDistanceToAttack = combatController.GetMinimalDistanceToAttack();
        InvokeRepeating("Patrol", 0f, .5f);
    }

    private void Patrol()
    {
        if (this.enemyToAttack != null) return;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(this.transform.position, rangeOfView, enemiesLayer);
        foreach (Collider2D enemy in enemies)
            if (enemy.GetComponent<DamageableBeing>().IsAlive())
                enemyToAttack = enemy.GetComponent<DamageableBeing>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, rangeOfView);
    }
}

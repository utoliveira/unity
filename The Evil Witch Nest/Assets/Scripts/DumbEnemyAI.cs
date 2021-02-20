using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbEnemyAI : MonoBehaviour
{

    private const string anim_param_speed = "speed";

    private bool isAlive = true;
    
    [SerializeField]
    private bool sleep = false;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private CharacterController2D characterController;
    private float horizontalMove;

    [SerializeField]
    private CombatController2D combatController;

    [SerializeField]
    private float fieldOfView;
    private DamageableBeing2D damageableEnemy;

    [SerializeField]
    private LayerMask enemyLayerMask;

    private float minimalDistanceToAttack;

    private void Start()
    {
        minimalDistanceToAttack = combatController.getMinimalDistanceToAttack();
        InvokeRepeating("lookForPlayer", 0f, .5f);
    }

    private void Update()
    {
        Move();
    }

    private void lookForPlayer()
    {
        if (damageableEnemy != null || sleep) return;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(this.transform.position, fieldOfView, enemyLayerMask);
        foreach (Collider2D enemy in enemies)
            if (enemy.GetComponent<DamageableBeing2D>().IsAlive())
                damageableEnemy = enemy.GetComponent<DamageableBeing2D>();
    }

    private void Move()
    {
        if (!isAlive || damageableEnemy == null || sleep) return;

        if (!damageableEnemy.IsAlive())
        {
            damageableEnemy = null;
            return;
        }

        float distanceFromPlayer = Vector2.Distance(damageableEnemy.transform.position, this.gameObject.transform.position);
 
        if (distanceFromPlayer > minimalDistanceToAttack)
            horizontalMove = (damageableEnemy.transform.position - this.gameObject.transform.position).normalized.x;
        else
            Attack();

        animator.SetFloat(anim_param_speed, Mathf.Abs(horizontalMove));
    }

    private void Attack()
    {
        horizontalMove = 0;
        combatController.Attack();
    }

    private void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.gameObject.transform.position, minimalDistanceToAttack);
        Gizmos.DrawWireSphere(this.gameObject.transform.position, fieldOfView);
    }

    public void OnDie()
    {
        isAlive = false;
        horizontalMove = 0;
    }

    public void setSleep(bool sleep)
    {
        this.sleep = sleep;
    }

}

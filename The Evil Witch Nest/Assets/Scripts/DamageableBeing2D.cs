using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageableBeing2D : MonoBehaviour
{

    private const string anim_param_receiveDamage = "receiveDamage";
    private const string anim_param_dead = "isDead";
  
    [SerializeField]
    private int maxHealth;
    private int currentHealth;

    [SerializeField]
    private Animator animator;

    [Space]
    [Header("After Dying")]
    [SerializeField]
    private Collider2D[] colliders;

    [SerializeField]
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private bool destroyAfterDie;

    [SerializeField]
    private float timeToDestroy = 1f;

    [SerializeField]
    private UnityEvent onDieEvent;

    private bool isInvencible = false;

    [SerializeField]
    private HealthBar healthBar;

    private void Awake()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
            healthBar.SetMaxHelth(maxHealth);
    }

    public void ReceiveDamage(int damagePoints)
    {

        if (isInvencible) return;

        if (currentHealth - damagePoints < 0)
            currentHealth = 0;
        else
            currentHealth -= damagePoints;

        if (currentHealth < 1)
            Die();
        else if (animator != null)
            animator.SetTrigger(anim_param_receiveDamage);

        if (healthBar != null)
            healthBar.SetHealth(currentHealth);
    }

    public void Heal(int healPoints)
    {
        if(currentHealth + healPoints > maxHealth)
            currentHealth = maxHealth;

        currentHealth += healPoints;

    }
    private void Die()
    {
        if(animator != null)
            animator.SetBool(anim_param_dead, true);

        if (onDieEvent != null)
            onDieEvent.Invoke();

        DisableComponents();

        if (destroyAfterDie)
            Destroy(this.gameObject, timeToDestroy);
    }

    private void DisableComponents()
    {
        rigidbody2D.gravityScale = 0;
        foreach(Collider2D collider in colliders)
            collider.enabled = false;

    }


    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public void setInvencible()
    {
        isInvencible = true;
    }

    public void removeInvencible()
    {
        isInvencible = false;
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Animator animator;

    public int maxHealth = 100;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

   public void takeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("TakeHit");
        if (currentHealth < 1)
            Die();
    }

    private void Die()
    {
        animator.SetBool("isDead", true);
        GetComponent<Rigidbody2D>().gravityScale = 0;
        foreach (Collider2D collider in GetComponents<Collider2D>()) {
            collider.enabled = false;  
        }
        this.enabled = false;
        Destroy(this.gameObject, 5f);
    }
}

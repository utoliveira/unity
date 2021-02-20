using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Gettable : MonoBehaviour
{

    public Animator animator;
    public Collider2D collider;

    public abstract void OnPlayerGet(GameObject player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ("Player".Equals(collision.tag))
        {
            collider.enabled = false;
            animator.SetBool("pegou", true);
            Destroy(this.gameObject, 1f);
            OnPlayerGet(collision.gameObject);
        }
    }

}

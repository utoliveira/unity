using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]
    private bool facingRight = true;

    private Vector3 velocity = Vector3.zero;

    [Range(0, .3f)]
    [SerializeField]
    private float movementSmoothing = .2f;


    [SerializeField]
    private LayerMask whatIsGround;
    
    [SerializeField]
    private Transform groundChecker;

    [SerializeField]
    public float groudChecker_range = 0.05f;
    private bool isGrounded;

    [SerializeField]
    private float jumpForce;

    public float speed;

    public UnityEvent OnLand;

    private void FixedUpdate()
    {
        checkJumping();
    }

    public void Move(float moveDirection, bool jump)
    {
        ApplyVelocity(moveDirection);

        if (moveDirection > 0 && !facingRight)
            Flip();
        else if (moveDirection < 0 && facingRight)
            Flip();

        if (isGrounded && jump)
            Jump();

    }

    private void ApplyVelocity(float move)
    {
        Vector3 targetVelocity = new Vector2(move * speed, rigidbody.velocity.y);
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref velocity, movementSmoothing);
    }

    private void Jump()
    {
        isGrounded = false;
        rigidbody.AddForce(new Vector2(0f, jumpForce));
    }

    private void Flip()
    {
        facingRight = !facingRight;

        this.transform.Rotate(0, 180, 0);
        // Multiply the player's x local scale by -1.
        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale = theScale;
    }

    private void checkJumping()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundChecker.position, groudChecker_range, whatIsGround);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != this.gameObject)
            {
                isGrounded = true;
                if (!wasGrounded)
                    OnLand.Invoke();

                return;
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundChecker.position, groudChecker_range);

    }

}

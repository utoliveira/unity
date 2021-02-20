using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private CharacterController2D characterController;

    [SerializeField]
    private CombatController combatController;

    [SerializeField]
    private Animator animator;

    private float horizontalMove;
    private bool jump;
    private bool crouch;
    private bool controllable;

    private void Start()
    {
        controllable = true;
    }

    void Update()
    {
        if (!controllable)
            return;

        CheckMovement();

        crouch = Input.GetButton(AxisConst.crouch);

        if (Input.GetButtonDown(AxisConst.jump))
            Jump();

        if (Input.GetButtonDown(AxisConst.attack))
            combatController.Attack();

    }


    private void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void Jump()
    {
        jump = true;
        animator.SetBool(AnimatorConst.isJumping, true);
    }

    private void CheckMovement()
    {
        horizontalMove = Input.GetAxisRaw(AxisConst.horizontal_move);
        animator.SetFloat(AnimatorConst.speed, Mathf.Abs(horizontalMove));
    }

    private void Attack()
    {

    }

    public void OnLandEvent()
    {
        animator.SetBool(AnimatorConst.isJumping, false);
        Debug.Log("Landou");
    }

    public void OnCrouchEvent(bool isCrouching)
    {
        animator.SetBool(AnimatorConst.isCrouching, isCrouching);
    }

    public void OnDieEvent()
    {
        controllable = false;
        animator.SetTrigger(AnimatorConst.die);
    }
}

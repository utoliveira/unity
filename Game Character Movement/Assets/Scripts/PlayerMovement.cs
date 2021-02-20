using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string JUMP_AXIS = "Jump";
    private const string CROUCH_AXIS = "Crouch";

    private const string SPEED_ANIM_PARAM = "Speed";
    private const string JUMPING_ANIM_PARAM = "Jumping";
    private const string CROUCHING_ANIM_PARAM = "Crouching";

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    private bool crouch = false;
    private bool jump = false;

    private void Update(){
        horizontalMove = Input.GetAxisRaw(HORIZONTAL_AXIS) * runSpeed;
        animator.SetFloat(SPEED_ANIM_PARAM, Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown(JUMP_AXIS)) {
            jump = true;
            animator.SetBool(JUMPING_ANIM_PARAM, true);
        }
        crouch = Input.GetButton(CROUCH_AXIS);
    }

    public void OnLanding()
    {
        animator.SetBool(JUMPING_ANIM_PARAM, false);
    }

    public void OnCrounching(bool iscrouching)
    {
        animator.SetBool(CROUCHING_ANIM_PARAM, iscrouching);
    }

    void FixedUpdate(){

        //fixedDeltaTime is the amount of time since the last time FixedUpdate was called.
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public const string axis_horizontal = "Horizontal";
    public const string axis_jump = "Jump";

    public const string anim_param_speed = "Speed";
    public const string anim_param_jump = "Jump";

    public float speed = 40f;
    public CharacterController2D controller;
    public Animator animator;

    private bool jump;
    private float horizontalSpeed;

    void Update(){
        
        horizontalSpeed = Input.GetAxisRaw(axis_horizontal) * speed;
        animator.SetFloat(anim_param_speed, Mathf.Abs(horizontalSpeed));

        if (Input.GetButtonDown(axis_jump)){
            animator.SetBool(anim_param_jump, true);
            jump = true;
        }

    }

    private void FixedUpdate(){
        controller.Move(horizontalSpeed * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void onLanding()
    {
        animator.SetBool(anim_param_jump, false);
    }

}

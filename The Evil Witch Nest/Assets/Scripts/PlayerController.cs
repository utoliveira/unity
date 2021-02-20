using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string axis_horizontal = "Horizontal";
    private const string axis_jump = "Jump";
    private const string axis_attack = "attack";

    private const string anim_param_jump = "isJumping";
    private const string anim_param_attack = "attack";
    private const string anim_param_speed = "speed";

    [SerializeField]  
    private CharacterController2D controller;

    [SerializeField]
    private CombatController2D fighterController;

    [SerializeField]
    private Animator animator;
  
    private float horizontalMove;
    private bool jump;

    // Update is called once per frame
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw(axis_horizontal);
        animator.SetFloat(anim_param_speed, Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown(axis_jump))
            Jump();

        if (Input.GetButtonDown(axis_attack))
            fighterController.Attack();
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    private void Jump()
    {
        jump = true;
        animator.SetBool(anim_param_jump, true);
    }

    public void OnLanding()
    {
        Debug.Log("Aterrizô");
        animator.SetBool(anim_param_jump, false);
    }
}

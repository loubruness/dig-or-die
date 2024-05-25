using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovements : MonoBehaviour
{

    public float speed = 5;

    private PlayerInput playerInput;
    private Vector2 moveInput;
    private bool jumpInput;
    private CharacterController controller;
    private Vector3 moveDirection;

    private float jumpForce = 8.0f;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();

        // Move Action
        playerInput.actions["Move"].performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.actions["Move"].canceled += ctx => moveInput = Vector2.zero;

        // Jump Action
        playerInput.actions["Jump"].performed += ctx => jumpInput = ctx.ReadValueAsButton();
        playerInput.actions["Jump"].canceled += ctx => jumpInput = false;
    }
    private void HandleMovement()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(moveInput.x, 0.0f, moveInput.y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            //_animator.SetBool("Run", moveInput.magnitude > 0);

        }
    }


    private void HandleJumping()
    {
        if (controller.isGrounded && jumpInput)
        {
            //_animator.SetTrigger("Jump");
            // Stop other velocity than the y velocity
            moveDirection.x = 0;
            moveDirection.z = 0;
            moveDirection.y = jumpForce;
        }


    }

    private void Update()
    {
        HandleMovement();
        HandleJumping();
        //moveDirection.y -= 9.8f * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

}

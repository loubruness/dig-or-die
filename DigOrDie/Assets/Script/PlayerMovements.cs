using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovements : MonoBehaviour
{

    public float speed = 5;
    public Transform TransplayerCamera;

    private PlayerInput playerInput;
    private Vector2 moveInput;
    private Vector2 lookInput;
    float xRotation = 0;
    float yRotation = 0;
    private bool jumpInput;
    private CharacterController controller;
    private Vector3 moveDirection;


    private float jumpForce = 8.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        //TransplayerCamera = GetComponentInChildren<Camera>().transform;
    

        // Move Action
        playerInput.actions["Move"].performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.actions["Move"].canceled += ctx => moveInput = Vector2.zero;

        // Look Action
        playerInput.actions["Look"].performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        playerInput.actions["Look"].canceled += ctx => lookInput = Vector2.zero;

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

    private void HandleLook()
    {
        float mouseX = lookInput.x;
        float mouseY = lookInput.y;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        TransplayerCamera.rotation = Quaternion.Euler(xRotation, yRotation, 0);


    }


    private void HandleJumping()
    {
        if (controller.isGrounded && jumpInput)
        {
            //_animator.SetTrigger("Jump");
            // Stop other velocity than the y velocity
            //moveDirection.x = 0;
            //moveDirection.z = 0;
            moveDirection.y = jumpForce;
        }


    }

    private void Update()
    {
        HandleMovement();
        HandleJumping();
        HandleLook();
        moveDirection.y -= 9.8f * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

}

using System;
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

    public Transform missionplace;
    public Transform objective1;
    public Transform objective2;
    public Transform treasure;


    private float jumpForce = 8.0f;
    public GameObject player;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Awake()
    {
        objective1 = GameObject.Find("Objective1").GetComponent<Transform>();
        objective2 = GameObject.Find("Objective2").GetComponent<Transform>();
        treasure = GameObject.Find("Treasure").GetComponent<Transform>();
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

        playerInput.actions["Dig"].performed += ctx => Dig();
    }
    private void HandleMovement()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(moveInput.x, 0.0f, moveInput.y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

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

    private void Dig()
    {
        missionplace = player.GetComponent<Compass>().missionplace;
        
        Debug.Log("Digging");
        Debug.Log("Missionplace.position "+ missionplace.position);
        Debug.Log("transform.position"+ transform.position);
        if(Math.Abs(transform.position.x - missionplace.position.x) <=2 && Math.Abs(transform.position.z - missionplace.position.z) <= 2)
        {
             Debug.Log("OKKK");
            if (player.GetComponent<Compass>().missionplace == objective1)
            {
                player.GetComponent<Compass>().missionplace = objective2;
            }
            else if (player.GetComponent<Compass>().missionplace == objective2)
            {
                player.GetComponent<Compass>().missionplace = treasure;
            }
        }
        
    }
}

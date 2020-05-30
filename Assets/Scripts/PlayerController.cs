using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private PlayerControls inputActions;
    private Vector2 movemmentInput;

    [SerializeField]
    private float moveSpeed = 5f;
    private Vector3 moveDirection;
    private Vector3 moveVector;
    private Quaternion currentRotation;
    public bool isGrounded;

    private Rigidbody rb;
    public GameObject model;

    private void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.Gameplay.Movement.performed += ctx => movemmentInput = ctx.ReadValue<Vector2>();
    }

    void Move(Vector3 desiredDirection)
    {
        moveVector.Set(desiredDirection.x, 0, desiredDirection.z);
        moveVector = moveVector * moveSpeed * Time.deltaTime;
        transform.position += moveVector;
    }

    void Turn(Vector3 desiredDirection)
    {
        if ((desiredDirection.x > 0.1 || desiredDirection.x < -0.1) || (desiredDirection.z > 0.1 || desiredDirection.z < -0.1))
        {
            currentRotation = Quaternion.LookRotation(desiredDirection);
            transform.rotation = currentRotation;
        }
        else
        {
            transform.rotation = currentRotation;
        }
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if(playerHealth.isAlive==true)
        {
            float h = movemmentInput.x;
            float v = movemmentInput.y;

            Vector3 targetInput = new Vector3(h, 0, v);

            moveDirection = Vector3.Lerp(moveDirection, targetInput, Time.deltaTime * 5f);

            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 cameraRight = Camera.main.transform.right;
            cameraForward.y = 0f;
            cameraRight.y = 0f;

            Vector3 desiredDirection = cameraForward * moveDirection.z + cameraRight * moveDirection.x;

            Move(desiredDirection);
            Turn(desiredDirection);
        }
        if(playerHealth.isAlive==false)
        {
            print("can't move");
        }
    }

















    //CharacterController characterController;

    //public float speed = 6.0f;
    //public float jumpSpeed = 8.0f;
    //public float gravity = 20.0f;

    //private Vector3 moveDirection = Vector3.zero;

    //void Start()
    //{
    //    characterController = GetComponent<CharacterController>();
    //}

    //void Update()
    //{
    //    if (characterController.isGrounded)
    //    {
    //        // We are grounded, so recalculate
    //        // move direction directly from axes

    //        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    //        moveDirection *= speed;

    //        if (Input.GetButton("Jump"))
    //        {
    //            moveDirection.y = jumpSpeed;
    //        }
    //    }

    //    // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
    //    // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
    //    // as an acceleration (ms^-2)
    //    moveDirection.y -= gravity * Time.deltaTime;

    //    // Move the controller
    //    characterController.Move(moveDirection * Time.deltaTime);
    //}
}

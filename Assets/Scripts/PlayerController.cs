using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Vector3 jump;
    public float jumpForce;
    private Rigidbody rb;
    public bool isGrounded;
    private PlayerHealth playerHealth;

    public GameObject model;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        jump = new Vector3(0f, 2f, 0f);
    }

    private void Update()
    {
        if(playerHealth.isAlive==true)
        {
            print("can move");
            if(Input.GetKey(KeyCode.D)|)
            {
                transform.position += transform.forward * Time.deltaTime * speed;
            }
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

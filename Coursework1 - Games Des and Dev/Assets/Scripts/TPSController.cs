using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask; 
    Animator animator;

    //Input variables
    float mouseX;
    float mouseY; 
    float mouseSensitivity = 800f;
    float horzAxis;
    float vertAxis;

    //Character controlls;
    float rotationX = 0f;
    float rotationY = 0f;
    Vector3 velocity;
    float moveSpeed = 5f;
    float jumpHeight = 0.5f;
    float gravity = -9.81f; 
    float grounDistance = 0.3f;
    bool isGrounded; 
    bool jumpTrigger; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Inputs();
        CheckIfGrounded(); 
        CheckJumpTrigger(); 
        ApplyMouseDirection();
        ApplyMovement();
    }

    void Inputs()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        horzAxis = Input.GetAxis("Horizontal");
        vertAxis = Input.GetAxis("Vertical");
        jumpTrigger = Input.GetButtonDown("Jump");
    }

    void CheckIfGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, grounDistance, groundMask);
        if(isGrounded == true && velocity.y < 0f)
        {
            velocity.y = 0f;
        }
        else if(isGrounded == false)
        {
            velocity.y += gravity * Time.deltaTime;
        }
    }

    void CheckJumpTrigger()
    {
        if(jumpTrigger && isGrounded)
        {
            animator.SetBool("jumpTrigger", true);
            Invoke("JumpMotion", 0.60f);
        }
        else
        {
            animator.SetBool("jumpTrigger", false);
        }
    }

    void JumpMotion()
    {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    void ApplyMouseDirection()
    {
        //look up and down based on mouse input
        rotationY -= mouseY * mouseSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        //look left and right based on mouse input
        rotationX = mouseX * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationX); 
    }

    void ApplyMovement ()
    {
        controller.Move(velocity * Time.deltaTime);
        Vector3 move = (transform.right * horzAxis) + (transform.forward * vertAxis);
        controller.Move(move * moveSpeed * Time.deltaTime);

        animator.SetBool("walkingBackTrigger", Input.GetKey(KeyCode.S));
        animator.SetBool("walkingTrigger", Input.GetKey(KeyCode.W));
    }
}

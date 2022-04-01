using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask; //to differenciate what things are on the ground 
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
    float moveSpeed = 10f;
    float jumpHeight = 0.5f;
    float gravity = -9.81f; //we don't define this as a rigid body, we do everything through the Character Controller component
    float grounDistance = 0.3f;
    bool isGrounded; 
    bool jumpTrigger; //true when the player is jumping

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        CheckIfGrounded(); //we apply gravity first
        CheckJumpTrigger(); //we need to call this before the ApplyMovement
        ApplyMouseDirection();
        ApplyMovement();
        //print("mouseX " + mouseX + " ,mouseY " + mouseY + " ,horzAxis " + horzAxis + " ,vertAxis " + vertAxis + " ,jumpTrigger " + jumpTrigger);
        //print("isGrounded " + isGrounded + ", jumpTrigger " + jumpTrigger);
        //print("velocity.y is " + velocity.y);
        //print("Time.deltaTime is " + Time.deltaTime);
    }

    void Inputs()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        horzAxis = Input.GetAxis("Horizontal"); //keyboard or joypad setup
        vertAxis = Input.GetAxis("Vertical");
        jumpTrigger = Input.GetButtonDown("Jump"); //space
    }

    void CheckIfGrounded() //also applies gravity
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, grounDistance, groundMask);
        if(isGrounded == true && velocity.y < 0f)
        {
            velocity.y = 0f; //does not let it keep falling through the ground
        }
        else if(isGrounded == false)
        {
            velocity.y += gravity * Time.deltaTime; //the gravity is negative so the velocity is negative - the player is falling
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
        //playerCamera.transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);

        //look left and right based on mouse input
        rotationX = mouseX * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationX); 
        //we use this to rotate the entire player controller, not just the camera
    }

    void ApplyMovement ()
    {
        controller.Move(velocity * Time.deltaTime);
        Vector3 move = (transform.right * horzAxis) + (transform.forward * vertAxis);
        controller.Move(move * moveSpeed * Time.deltaTime);

        animator.SetBool("walkingBackTrigger", Input.GetKey(KeyCode.S));
        animator.SetBool("walkingTrigger", Input.GetKey(KeyCode.W));
        
        //animator.SetBool("throwTrigger", Input.GetKey(KeyCode.E));
    }
}

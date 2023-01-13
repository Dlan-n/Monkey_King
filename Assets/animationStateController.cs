using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    CharacterController characterController;
    int isWalkingHash;
    int isRunningHash;
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        //increases performance
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        //taking in the horizontal and vertical axis input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //determines the direction of movement along the x and y axis
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        characterController.SimpleMove(movementDirection * magnitude);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }




        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        //if player presses w key
        if(!isWalking && forwardPressed)
        {
            //then set the isWalking boolean to be true
            animator.SetBool("isWalking", true);
        }
        //if player is not pressing w key
        if (isWalking && !forwardPressed)
        {
            //then set the isWalking boolean to be true
            animator.SetBool("isWalking", false);
        }
        //if player is walking and not running and presses left shift
        if (!isRunning && (forwardPressed && runPressed))
        {
            //set the isRunning boolean to be true
            animator.SetBool("isRunning", true);
        }
        //if player is running and stops running or walking
        if (isRunning && (!forwardPressed && !runPressed))
        {
            //set the isRunning boolean to be false
            animator.SetBool("isRunning", false);
        }
        
    }
}

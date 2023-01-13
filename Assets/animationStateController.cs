using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        //increases performance
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
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

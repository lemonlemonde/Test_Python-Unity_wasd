using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    // get animator controller
    public Animator animator;
    // get the model
    public GameObject character;
    public float speedForward = 2.0f;
    public float speedBackward = 1.0f;
    public float speedLeft = 1.0f;
    public float speedRight = 1.0f;

    private bool curFrameFinished = false;

    private float deltaTime = 0f;
    private Vector3 deltaNewPos = new Vector3(0, 0, 0);
    private int newAnim = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // // on key press w
        // if (Input.GetKey(KeyCode.W)) {
        //     MoveForward();
        // } else if (Input.GetKey(KeyCode.A)) {
        //     MoveLeft();
        // } else if (Input.GetKey(KeyCode.S)) {
        //     MoveBackward();
        // } else if (Input.GetKey(KeyCode.D)) {
        //     MoveRight();
        // } else {
        //     animator.SetInteger("WASD", 0);
        // }

        character.transform.Translate(Time.deltaTime * deltaNewPos);
        animator.SetInteger("WASD", newAnim);

        
    }

    public void MoveForward()
    {
        Debug.Log("moving forward...");
        deltaNewPos = speedForward * Vector3.forward;
        newAnim = 1;
        
    }

    public void MoveBackward()
    {
        Debug.Log("moving backward...");
        deltaNewPos = speedBackward * Vector3.back;
        newAnim = 3;
    }

    public void MoveLeft()
    {
        Debug.Log("moving left...");
        deltaNewPos = speedLeft * Vector3.left;
        newAnim = 2;

    }

    public void MoveRight()
    {
        Debug.Log("moving right...");
        deltaNewPos = speedRight * Vector3.right;
        newAnim = 4;
    }

    public void Idle()
    {
        Debug.Log("idling...");
        newAnim = 0;
    }

    public void Command(string command)
    {
        Debug.Log("received: " + command);
        if (command.Contains("up")) {
            Idle();
            // reset 
            deltaNewPos = new Vector3(0, 0, 0);
            newAnim = 0;
        } else if (command.Contains("down")) {
            if (command[0] == 'w') {
                MoveForward();
            } else if (command[0] == 'a') {
                MoveLeft();
            } else if (command[0] == 's') {
                MoveBackward();
            } else if (command[0] == 'd') {
                MoveRight();
            } else {
                Idle();
            }
        } 


        
    }


}

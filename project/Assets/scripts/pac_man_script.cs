//=====================================================
// pac_man_script.cs
// 3/2/2020
// Hunter Bradley
// Last Updated: 3/2/2020
// 
// Is a script that allows Pac man to move and runs into pellets to
// Eat them
//=====================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pac_man_script : MonoBehaviour
{
    //Pacman's current Speed
    public int pacSpeed = 1;

    //Collider Threshold
    public float threshold = 0.1f;

    // Last Input "Ennum" to decide which way pac-man will moves
    // Up    = 0
    // Down  = 1
    // Right = 2
    // Left  = 3
    int lastInput;

    // Controls which direction Pacman is going
    // Up    = 0
    // Down  = 1
    // Right = 2
    // Left  = 3
    int moveInput;

    Vector2 movement;

    Rigidbody2D rigidbody2d;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        lastInput = 2;
        moveInput = 2;

        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the Up key is pressed, Set the lastInput to Up
        if (Input.GetKey(KeyCode.UpArrow) /*&& lastInput != 0*/)
        {
            if (moveInput == 1)
            {
                moveInput = 0;
            }

            lastInput = 0;

            Debug.Log(lastInput);
        }

        //If the Down key is pressed, Set the lastInput to Down
        else if (Input.GetKey(KeyCode.DownArrow) /*&& lastInput != 1*/)
        {
            if (moveInput == 0)
            {
                moveInput = 1;
            }

            lastInput = 1;

            Debug.Log(lastInput);
        }
        
        //If the Right key is pressed, Set the lastInput to Right
        else if (Input.GetKey(KeyCode.RightArrow) /*&& lastInput != 2*/)
        {
            if (moveInput == 3)
            {
                moveInput = 2;
            }

            lastInput = 2;

            Debug.Log(lastInput);
        }

        //If the Left key is pressed, Set the lastInput to Left
        else if (Input.GetKey(KeyCode.LeftArrow) /*&& lastInput != 3*/)
        {
            if(moveInput == 2)
            {
                moveInput = 3;
            }

            lastInput = 3;

            Debug.Log(lastInput);
        }

        PacManMovement();

    }

    //Will move PacMan based on the last given Input
    void PacManMovement()
    {
        movement = rigidbody2d.position;

        if (moveInput == 0)
        {
            movement.y = movement.y + 1.0f * pacSpeed * Time.deltaTime;
        }

        else if (moveInput == 1)
        {
            movement.y = movement.y - 1.0f * pacSpeed * Time.deltaTime;
        }

        else if (moveInput == 2)
        {
            movement.x = movement.x + 1.0f * pacSpeed * Time.deltaTime;
        }

        else if (moveInput == 3)
        {
            movement.x = movement.x - 1.0f * pacSpeed * Time.deltaTime;
        }

        rigidbody2d.position = movement;

        animator.SetFloat("Input", moveInput);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "trigger_tile" 
            && Mathf.Abs(collider.transform.position.x - transform.position.x) <= threshold
            && Mathf.Abs(collider.transform.position.y - transform.position.y) <= threshold)
        {
            moveInput = lastInput;
        }

        //Eating Parts of function
        if (collider.gameObject.tag == "pellet")
        {
            
        }

        else if (collider.gameObject.tag == "fruit")
        {
            
        }

    }
}

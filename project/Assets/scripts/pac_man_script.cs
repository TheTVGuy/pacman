﻿//=====================================================
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

    // Last Input Ennum to decide which way pac-man moves
    // Up    = 0
    // Down  = 1
    // Right = 2
    // Left  = 3
    int lastInput;

    Vector2 movement;

    public Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        lastInput = 2;

        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = rigidbody2d.velocity;

        //If the Up key is pressed, Set the lastInput to Up
        if (Input.GetKeyDown(KeyCode.UpArrow) /*&& lastInput != 0*/)
        {
            lastInput = 0;

            movement.y = movement.y + 1.0f * pacSpeed * Time.deltaTime;

            Debug.Log(lastInput);
        }

        //If the Down key is pressed, Set the lastInput to Down
        else if (Input.GetKeyDown(KeyCode.DownArrow) /*&& lastInput != 1*/)
        {
            lastInput = 1;

            movement.y = movement.y - 1.0f * pacSpeed * Time.deltaTime;

            Debug.Log(lastInput);
        }

        //If the Right key is pressed, Set the lastInput to Right
        else if (Input.GetKeyDown(KeyCode.RightArrow) /*&& lastInput != 2*/)
        {
            lastInput = 2;

            movement.x = movement.x + 1.0f * pacSpeed * Time.deltaTime;

            Debug.Log(lastInput);
        }

        //If the Left key is pressed, Set the lastInput to Left
        else if (Input.GetKeyDown(KeyCode.LeftArrow) /*&& lastInput != 3*/)
        {
            lastInput = 3;

            movement.x = movement.x - 1.0f * pacSpeed * Time.deltaTime;

            Debug.Log(lastInput);
        }

        rigidbody2d.velocity = movement;

    }

    //PacMan Eating Function
    void OnCollition2D(GameObject other)
    {


    }

}

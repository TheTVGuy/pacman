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

public class pac_man_movement : MonoBehaviour
{
    //Pacman's current Speed
    public int pacSpeed = 1;

    // Last Input Ennum to decide which way pac-man moves
    // Up    = 0
    // Down  = 1
    // Right = 2
    // Left  = 3

    int lastInput;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If the Up key is pressed, Set the lastInput to Up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            lastInput = 0;
            Debug.Log(lastInput);
        }

        //If the Down key is pressed, Set the lastInput to Down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            lastInput = 1;
            Debug.Log(lastInput);
        }
    }
}

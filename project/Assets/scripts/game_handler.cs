//=====================================================
// game_handler.cs
// 3/4/2020
// Hunter Bradley
// Last Updated: 3/4/2020
// 
// Is a script that handles the Game
//=====================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_handler : MonoBehaviour
{
    //The Score Variable
    public int score = 0;

    //The Number of pellets in the level
    public int pellets = 1;

    //The Last High Score
    public int highScore;

    //the Number of Lives
    public int lives = 3;

    //the Level Counter
    public int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pellets == 0)
        {
            NextLevel();
        }
    }

    //Adds the Current point value to the Score
    void AddPoints(int value)
    {
        score += value;
    }

    //Increases the current Level to the next Level
    void NextLevel()
    {
        level++;
        //Add code here for Items that change in between levels
        //Like Speed of objects, Points, chase and scatter times, etc.

    }
}

// ----------------------------------------
//
// File: screen_wrap.cs
//
// Contributors: Myles Busig
// Date Created: 03-03-2020
// Last Edited: 03-03-2020
//
// ---------------------------------------

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Wraps an object from one side of the screen to the other
public class screen_wrap : MonoBehaviour
{
	public float width = 15;
	
	new Rigidbody2D rigidbody = null;
	
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < -width /*&& rigidbody.velocity.x < 0.0f*/)
			transform.position = new Vector2(width, transform.position.y);
		if (transform.position.x > width /*&& rigidbody.velocity.x > 0.0f*/)
			transform.position = new Vector2(-width, transform.position.y);
    }
}

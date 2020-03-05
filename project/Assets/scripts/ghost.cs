// ----------------------------------------
//
// File: ghost.cs
//
// Contributors: Myles Busig
// Date Created: 03-02-2020
// Last Edited: 03-04-2020
//
// ----------------------------------------

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An enum used to represent a ghost type
public enum ghost_type
{
	Red,
	Blue,
	Pink,
	Orange
}

// Selects a tile based on the ghost type, and pac-man's position,
// and then moves towards that position
public class ghost : MonoBehaviour
{
	public ghost_type type = ghost_type.Red;
	public float speed = 3.0f;
	public float threshold = 0.1f;
	
	GameObject player = null;
	Vector2 currentDirection = Vector2.left;
	Vector2 targetPosition = Vector2.zero;
	GameObject lastTile = null;
	
	new Rigidbody2D rigidbody = null;
	Animator animator = null;
	
	// Initializes the component variables
    void Start()
    {
		rigidbody = GetComponent<Rigidbody2D>();
		rigidbody.velocity = currentDirection * speed * Time.deltaTime;
		
		animator = GetComponent<Animator>();
		
        player = GameObject.FindWithTag("player");
    }
	
	// Occurs when a trigger object collides with the ghost
	// Arguments:
	//   collider = The collider event arguments
	void OnTriggerStay2D(Collider2D collider)
	{
		// Ignore the collision if the object is not a tile,
		// has already been handled, or is not at the center of the object
		if (collider.gameObject != lastTile
			&& collider.gameObject.tag == "trigger_tile"
			&& Mathf.Abs(collider.transform.position.x - transform.position.x) <= threshold
			&& Mathf.Abs(collider.transform.position.y - transform.position.y) <= threshold)
		{
			lastTile = collider.gameObject;
			
			// Set the target tile using the ghost type
			if (type == ghost_type.Red)
				SetTileRed();
			else if (type == ghost_type.Blue)
				SetTileBlue();
			else if (type == ghost_type.Pink)
				SetTilePink();
			else if (type == ghost_type.Orange)
				SetTileOrange();
			
			MoveToTile();
		}
	}
	
	// Sets the target tile for a red ghost
	void SetTileRed()
	{
		targetPosition = player.transform.position;
	}
	// Sets the target tile for a blue ghost
	void SetTileBlue()
	{
		
	}
	// Sets the target tile for a blue ghost
	void SetTilePink()
	{
		
	}
	// Sets the target tile for a orange ghost
	void SetTileOrange()
	{
		
	}
	
	// Moves the ghost towards the current target tile
	void MoveToTile()
	{
		Vector2 direction = targetPosition - (Vector2)transform.position;
		
		Vector2 newDirection = Vector2.zero;
		float smallestAngle = 10.0f;
		
		trigger_tile tile = lastTile.GetComponent<trigger_tile>();
		
		// Get the shortest direction by checking for the smallest
		// angle between the new direction, and the direction to the tile,
		// and then storing the new direction
		if (tile.left && currentDirection.x != 1.0f)
		{
		 	float angle = Mathf.Acos(Vector2.Dot(direction, Vector2.left)
				/ direction.magnitude);
			
			if (angle < smallestAngle)
			{
				smallestAngle = angle;
				newDirection = Vector2.left;
			}
		}
		if (tile.right && currentDirection.x != -1.0f)
		{
		 	float angle = Mathf.Acos(Vector2.Dot(direction, Vector2.right)
				/ direction.magnitude);
			
			if (angle < smallestAngle)
			{
				smallestAngle = angle;
				newDirection = Vector2.right;
			}
		}
		if (tile.up && currentDirection.y != -1.0f)
		{
		 	float angle = Mathf.Acos(Vector2.Dot(direction, Vector2.up)
				/ direction.magnitude);
			
			if (angle < smallestAngle)
			{
				smallestAngle = angle;
				newDirection = Vector2.up;
			}
		}
		if (tile.down && currentDirection.y != 1.0f)
		{
		 	float angle = Mathf.Acos(Vector2.Dot(direction, Vector2.down)
				/ direction.magnitude);
			
			if (angle < smallestAngle)
			{
				smallestAngle = angle;
				newDirection = Vector2.down;
			}
		}
		
		// Update the new direction and velocity
		currentDirection = newDirection;
		rigidbody.velocity = currentDirection * speed * Time.deltaTime;
		
		// Set the animation variables
		animator.SetBool("left", (newDirection.x == -1.0f));
		animator.SetBool("right", (newDirection.x == 1.0f));
		animator.SetBool("up", (newDirection.y == 1.0f));
		animator.SetBool("down", (newDirection.y == -1.0f));
	}
}

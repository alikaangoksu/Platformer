﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GroundCheck : MonoBehaviour {

	PlayerMovement move;

	// Use this for initialization
	void Start () {
		move = GetComponentInParent<PlayerMovement> ();
	}
	

	void  validGround() {
		//Player is allowed to jump
		move.checkJump = true;
	}

	void unvalidGround () {
		//Player is not allowed to jump
		move.checkJump = false;
	}

}

public class PlayerMovement : MonoBehaviour {

	//The player Movement Speed
	public float moveSpeed = 5f;


	//The speed of the player jump
	public float jumpSpeed = 10f;
	//check for if player allowed jump
	public bool checkJump;

	//Number of times the player has died
	[HideInInspector]
	public int deaths;

	//Death Counter:
	public Text deathText;


	[HideInInspector]
	public Rigidbody2D rb;
	//starting location
	public GameObject startLoc;

	// Use this for initialization
	void Start () {
		//Referencing the RigidBody that we added to the player game object, so we can change the parameters in it
		rb = GetComponent<Rigidbody2D> ();
		
	}


	
	// Update is called once per frame
	void Update () {

		//Setting the death count to be accurate
		deathText.text = "Deaths: " + deaths.ToString();

		//Horizontal moves
		//If the player presses left arrow, move left with initialized movement speed
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
		}

		//If the player presses right arrow,move right with initialized movement speed
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
		}

		//If the player stops pressing left arrow, stop moving
		if(Input.GetKeyUp(KeyCode.LeftArrow)){
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}

		//If the player stops pressing right arrow, stop moving
		if(Input.GetKeyUp(KeyCode.RightArrow)){
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}

		

		//JUMPING
		//If the player presses up arrow
		//check if player allowed jump
		
		if(Input.GetKey(KeyCode.UpArrow) && checkJump){
			rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
		}

	}
		//if player dies return to starting point
		//increased death counter
	public void Die() {
		rb.position = startLoc.transform.position;
		deaths++;
	}
		
}

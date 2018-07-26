﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float moveSpeed; // Multiplier that stands for the Speed of the Object's movement
	private Vector3 pos; // Constructor to hold the current Position of this Object
	
	void Update () {
		pos = gameObject.transform.position; // Updating the variable's value
		if(Input.GetButton("Horizontal")) { // Whenever the A, D or Left, Right Keys are used it'll move either left or right
			if(Input.GetAxis("Horizontal") > 0) {
				pos += transform.right * Time.deltaTime * moveSpeed; // Gets the desired x value
			}
			if(Input.GetAxis("Horizontal") < 0) {
				pos -= transform.right * Time.deltaTime * moveSpeed; // Gets the desired x value
			}
		}
		if(Input.GetButton("Vertical")) { // whenever the W, S or Up, Down Keys are used it'll move either Up or Down
			if(Input.GetAxis("Vertical") > 0) {
				pos += transform.forward * Time.deltaTime * moveSpeed; // Gets the desired z value
			}
			if(Input.GetAxis("Vertical") < 0) {
				pos -= transform.forward * Time.deltaTime * moveSpeed; // Gets the desired z value
			}
		}
		transform.position = pos; // Updates the position of the Object with the desired values
	}
}

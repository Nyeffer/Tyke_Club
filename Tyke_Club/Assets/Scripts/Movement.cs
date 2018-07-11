using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float moveSpeed; // Multiplier that stands for the Speed of the Player's movement
	private Vector3 pos;
	void Start () {

	}
	
	void Update () {
		pos = gameObject.transform.position;
		if(Input.GetButton("Horizontal")) {
			pos.x += Input.GetAxis("Horizontal") * moveSpeed;
		}
		if(Input.GetButton("Vertical")) {
			pos.z += Input.GetAxis("Vertical") * moveSpeed;
		}
		gameObject.transform.position = pos;
	}
}

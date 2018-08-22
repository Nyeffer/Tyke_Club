using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float moveSpeed; // Multiplier that stands for the Speed of the Object's movement
	public Transform newLoc;
	private Vector3 pos; // Constructor to hold the current Position of this Object
	private Animator anim;
	private bool isAble;
	private bool isRunning;
	private bool isRunning_Back;
	private bool isStrafing_Left;
	private bool isStrafing_Right;

	void Start() {
		anim = GetComponent<Animator>();
		isRunning = false;
		isRunning_Back = false;
		isStrafing_Left = false;
		isStrafing_Right = false;
		isAble = true;
	}
	
	void Update () {
		pos = gameObject.transform.position; // Updating the variable's value
		if(Input.GetButton("Horizontal") && isAble) { // Whenever the A, D or Left, Right Keys are used it'll move either left or right
			if(Input.GetAxis("Horizontal") > 0) {
				isStrafing_Left = false;
				isStrafing_Right = true;
				anim.SetBool("isStrafing_Left", isStrafing_Left);
				anim.SetBool("isStrafing_Right", isStrafing_Right);
				pos += transform.right * Time.deltaTime * moveSpeed; // Gets the desired x value
			}
			if(Input.GetAxis("Horizontal") < 0) {
				isStrafing_Left = true;
				isStrafing_Right = false;
				anim.SetBool("isStrafing_Left", isStrafing_Left);
				anim.SetBool("isStrafing_Right", isStrafing_Right);
				pos -= transform.right * Time.deltaTime * moveSpeed; // Gets the desired x value
			}
		} else {
			isStrafing_Left = false;
			isStrafing_Right = false;
			anim.SetBool("isStrafing_Left", isStrafing_Left);
			anim.SetBool("isStrafing_Right", isStrafing_Right);
		}
		if(Input.GetButton("Vertical") && isAble) { // whenever the W, S or Up, Down Keys are used it'll move either Up or Down
			if(Input.GetAxis("Vertical") > 0) {
				isRunning = false;
				isRunning_Back = true;
				anim.SetBool("isRunning_Back", isRunning_Back);
				anim.SetBool("isRunning", isRunning);
				pos += transform.forward * Time.deltaTime * moveSpeed; // Gets the desired z value
			}
			if(Input.GetAxis("Vertical") < 0) {
				isRunning = true;
				isRunning_Back = false;
				anim.SetBool("isRunning_Back", isRunning_Back);
				anim.SetBool("isRunning", isRunning);
				pos -= transform.forward * Time.deltaTime * moveSpeed; // Gets the desired z value
			}
		} else {
			isRunning = false;
			isRunning_Back = false;
			anim.SetBool("isRunning_Back", isRunning_Back);
			anim.SetBool("isRunning", isRunning);
		}
		transform.position = pos; // Updates the position of the Object with the desired values
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Wall") {
			gameObject.transform.position = newLoc.transform.position;
			gameObject.transform.rotation = newLoc.transform.rotation;
			isAble = false;
		} 
	}

	void OnTriggerExit(Collider col) {
		if(col.gameObject.tag == "Wall") {
			isAble = true;
		}
	}
}

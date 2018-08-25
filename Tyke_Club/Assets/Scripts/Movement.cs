using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float moveSpeed; // Multiplier that stands for the Speed of the Object's movement
	private BoxCollider col;
	public GameObject[] weapon;
	private GameObject myWeapon;
	public Transform forwardLoc;
	public Transform backLoc;
	public Transform leftLoc;
	public Transform rightLoc;
	private Vector3 pos; // Constructor to hold the current Position of this Object
	private Animator anim;
	private bool isAble;
	private bool isRunning;
	private bool isRunning_Back;
	private bool isStrafing_Left;
	private bool isStrafing_Right;
	private float atk_cd = 0.0f;

	void Start() {
		AlterCollider(Getweapon(PlayerPrefs.GetInt("Weapon", 0)), false);
		anim = GetComponent<Animator>();
		isRunning = false;
		isRunning_Back = false;
		isStrafing_Left = false;
		isStrafing_Right = false;
		isAble = true;
	}
	
	void Update () {
		pos = gameObject.transform.position; // Updating the variable's value
		if(Input.GetButton("Fire1")) {
			isAble = false;
			AlterCollider(Getweapon(PlayerPrefs.GetInt("Weapon", 0)), true);
			int rand = Random.Range(1,3);
			switch(rand) {
				case 1:
					anim.SetBool("isAttacking_1", true);
				break;
				case 2:
					anim.SetBool("isAttacking_2", true);
				break;
				default:
				break;
			}
		}
		if(!isAble) {
			if(atk_cd <= 1.5f) {
				atk_cd += Time.deltaTime;
			} else {
				AlterCollider(Getweapon(PlayerPrefs.GetInt("Weapon", 0)), false);
				anim.SetBool("isAttacking_1", false);
				anim.SetBool("isAttacking_2", false);
				isAble = true;
				atk_cd = 0.0f;
			}
		}
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
				isRunning = true;
				isRunning_Back = false;
				anim.SetBool("isRunning_Back", isRunning_Back);
				anim.SetBool("isRunning", isRunning);
				pos += transform.forward * Time.deltaTime * moveSpeed; // Gets the desired z value
			}
			if(Input.GetAxis("Vertical") < 0) {
				isRunning = false;
				isRunning_Back = true;
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
			if(isRunning) {
				gameObject.transform.position = forwardLoc.transform.position;
			}
			if(isRunning_Back) {
				gameObject.transform.position = backLoc.transform.position;
			}
			if(isStrafing_Left) {
				gameObject.transform.position = leftLoc.transform.position;
			}
			if(isStrafing_Right) {
				gameObject.transform.position = rightLoc.transform.position;
			}
			gameObject.transform.rotation = forwardLoc.transform.rotation;
			isAble = false;
		} 
	}

	void OnTriggerExit(Collider col) {
		if(col.gameObject.tag == "Wall") {
			isAble = true;
		}
	}

	public void AlterCollider(GameObject gO, bool istrue) {
		col = gO.GetComponent<BoxCollider>();
		col.enabled = istrue;
	 }

	 public GameObject Getweapon(int id) { // This function Take In the Id(Namely the PlayerPrefs "Weapon") 
		switch(id) {
			case 0:
				myWeapon = weapon[0];
			break;
			case 1:
				myWeapon = weapon[1];
			break;
			case 2:
				myWeapon = weapon[2];
			break;
			default:
			break;
		}
		return myWeapon;
 	}
}

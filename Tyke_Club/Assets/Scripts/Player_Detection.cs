using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detection : MonoBehaviour {
	private GameObject target;
	private Rigidbody rigidbody;
	public Vector3 velocity;
	public bool isSeeking;
	public float moveSpeed;
	private int numOfPoints;
	float counter = 0;
	float otherCounter = 0;
	private bool isDamaging = false;
	private Animator childAnim;
	private bool child;
	public GameObject weapon;

	private float distanceToSeek;

	void Awake() {
		rigidbody = GetComponent<Rigidbody>();
		velocity = rigidbody.velocity;
		distanceToSeek = GetComponent<SphereCollider> ().radius;
	}

	void Start() {
		childAnim = GetComponentInChildren<Animator>();
		weapon.SetActive(false);
	}

	void Update() {
		child = GetComponentInChildren<EnemyHealth>().GetisDead();
		if(child) {
			childAnim.SetBool("isDead", true);
			
			if(counter >= 10.0f) {
				counter = 0;
				Destroy(this.gameObject);
			} else {
				isSeeking = false;
				counter += Time.deltaTime;
			}
		}
	}

	void FixedUpdate() {
		if(isSeeking && !child) {
			if(Vector3.Distance(target.transform.position, this.transform.position) < distanceToSeek + 5) {
				Vector3 pos = target.transform.position - this.transform.position;
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(pos), 0.1f);
				if (!isDamaging) {
					if (pos.magnitude > 2.5f) {
						this.transform.Translate (0, 0, moveSpeed * Time.deltaTime);
					} else {
						isDamaging = true;
						childAnim.SetBool("isAttacking", true);
						weapon.SetActive(true);
					} 
				} else {
					if (counter <= 0.5f) {
						childAnim.SetBool("isAttacking", false);
						counter = 0;
						isDamaging = false;
					} else {
						this.transform.Translate (0, 0, (moveSpeed * 0) * Time.deltaTime);
						counter += Time.deltaTime;
					}
				}
			} 
		}
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Player") {
			target = col.gameObject;
			isSeeking = true;	
		}
	}

	void OnTriggerStay(Collider col) {
		if(col.gameObject.tag == "Player") {
			target = col.gameObject;
			isSeeking = true;	
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.tag == "Player") {
			target = null;
			isSeeking = false;
		}
 	}
}

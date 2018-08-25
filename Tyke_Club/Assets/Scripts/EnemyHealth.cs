using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int curHealth;

	private GameObject Player_bullet;
    public GameObject player;
	public GameObject parent;

	private Renderer renderer;

	bool isDead;
	bool isDamaged;

	void Awake() {
		renderer = GetComponent<Renderer>();
		curHealth = maxHealth;
		TakeDamage(0);
	}

	void Update() {
		if(isDamaged) {
			// Do Something
		} else {
			// Do Something else
		} 
		isDamaged = false;
	}

	public void TakeDamage(int damageDealt) {
		isDamaged = true;
		curHealth -= damageDealt;
		Debug.Log("Hit");
		if(curHealth <= 0 && !isDead) {
			Death();
		}
	}

	void Death() {
		isDead = true;
		
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "Player_Weapon" && gameObject.tag == "Enemy") {
			GetComponentInParent<Rigidbody>().AddForce(Vector3.back * 100, ForceMode.Force);
			GetComponentInParent<Player_Detection>().SetIsSeeking(false);
			TakeDamage(20);
			Debug.Log("Hit");
		}

 	}

	public bool GetisDead() {
		return isDead;
	}
}

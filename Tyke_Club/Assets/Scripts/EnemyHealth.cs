using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int curHealth;

	private GameObject Player_bullet;
    public GameObject player;

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

		if(curHealth <= 0 && !isDead) {
			if(Random.RandomRange(0,2) == 1) {
				Death();
			} else {
				Death();
			}
		}
	}

	void Death() {
		GetComponent<CapsuleCollider>().enabled = false;
		isDead = true;
	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "PlayerObjects" && gameObject.tag == "Enemy") {
			Player_bullet = col.gameObject;
			Destroy(col.gameObject);
		}
 	}

	public bool GetisDead() {
		return isDead;
	}
}

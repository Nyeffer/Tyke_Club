using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public Transform[] spawnPoints;
	public float spawnPerSec;
	public GameObject Object;
	private int rand;
	private float counter;

	void Update() {
		if(counter >= (1/spawnPerSec)) {
			Instantiate(Object, 
						new Vector3(spawnPoints[GetRand()].transform.position.x + GetRand(), spawnPoints[GetRand()].transform.position.y, spawnPoints[GetRand()].transform.position.z + GetRand()), 
						Quaternion.identity);
			counter = 0.0f;
		} else {
			counter += Time.deltaTime;
		}
		Debug.Log(counter);
	}

	int GetRand() {
		rand = Random.Range(0, spawnPoints.Length);
		return rand;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	public float xRotation = 90.0f;
 	public float xRotation1 = 0.0f;
 	public float RotationSpeed = 2.0f;
	private float counter = 0.0f;
 
 // Update is called once per frame
	void Update () 
	{
		counter += Time.deltaTime;
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, counter * 10, transform.eulerAngles.z);
		if(counter >= 360.0f) {
			counter = 0;
		}
	}
}

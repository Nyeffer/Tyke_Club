using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public GameObject[] weapon; // Array to store all of the possible Weapon

	void Start() {
		PlayerPrefs.GetInt("Weapon", 0); // PlayerPrefs name Weapon that determine switch Weapon that Player Use
	}

	void Update() {
		Getweapon(PlayerPrefs.GetInt("Weapon", 0));
	}

	public void Getweapon(int id) { // This function Take In the Id(Namely the PlayerPrefs "Weapon") 
		switch(id) {
			case 0:
				weapon[0].SetActive(true);
				weapon[1].SetActive(false);
				weapon[2].SetActive(false);
			break;
			case 1:
				weapon[1].SetActive(true);
				weapon[0].SetActive(false);
				weapon[2].SetActive(false);
			break;
			case 2:
				weapon[2].SetActive(true);
				weapon[1].SetActive(false);
				weapon[0].SetActive(false);
			break;
			default:
			break;
		}
 	}

	 public void ChangeWeapon() { // This Function change the PlayerPref Weapon Incremently
		 if(PlayerPrefs.GetInt("Weapon", 0) >= weapon.Length - 1) {
			 PlayerPrefs.SetInt("Weapon", 0);
		 } else {
			  PlayerPrefs.SetInt("Weapon", PlayerPrefs.GetInt("Weapon", 0) + 1);
		 }
	 }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {

	public GameObject[] armor; // Array to store all of the possible Weapon

	void Start() {
		PlayerPrefs.GetInt("Armor", 0); // PlayerPrefs name Weapon that determine switch Weapon that Player Use
	}

	void Update() {
		GetArmor(PlayerPrefs.GetInt("Armor", 0));
	}

	public void GetArmor(int id) { // This function Take In the Id(Namely the PlayerPrefs "Weapon") 
		switch(id) {
			case 0:
				armor[0].SetActive(true);
				armor[1].SetActive(false);
				armor[2].SetActive(false);
			break;
			case 1:
				armor[1].SetActive(true);
				armor[0].SetActive(false);
				armor[2].SetActive(false);
			break;
			case 2:
				armor[2].SetActive(true);
				armor[1].SetActive(false);
				armor[0].SetActive(false);
			break;
			default:
			break;
		}
 	}

	 public void ChangeArmor() { // This Function change the PlayerPref Weapon Incremently
		 if(PlayerPrefs.GetInt("Armor", 0) >= armor.Length - 1) {
			 PlayerPrefs.SetInt("Armor", 0);
		 } else {
			  PlayerPrefs.SetInt("Armor", PlayerPrefs.GetInt("Armor", 0) + 1);
		 }
	 }
}

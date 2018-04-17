using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour {
	public float CurrentHealth { get; set;}
	public float MaxHealth { get; set; }
	public Slider CastleHealthBar;

	// Use this for initialization
	void Start () {
		MaxHealth = 200f;
		CurrentHealth = MaxHealth;
		CastleHealthBar.value = CalculateHealth ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.K)) {
			DealDamage (2);
		}
	}

	void DealDamage(float damageValue){
		CurrentHealth -= damageValue;
		CastleHealthBar.value = CalculateHealth ();
		if (CurrentHealth <= 0) {
			GameOver ();
		}
	}

	float CalculateHealth(){
		return CurrentHealth / MaxHealth;
	}
	void GameOver(){
		CurrentHealth = 0;
		Debug.Log ("Suohi Legion Took Over the Castle....You're a SUOHI footman now.");
	}
}

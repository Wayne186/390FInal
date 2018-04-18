using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour {
	public static float CurrentHealth { get; set;}
	public static float MaxHealth { get; set; }
	public Slider CastleHealthBar;
	private string enemy;

	// Use this for initialization
	void Start () {
		MaxHealth = 160f;
		CurrentHealth = MaxHealth;
		CastleHealthBar.value = CalculateHealth ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.K)) {
			DealDamage (2);
		}
	}

	//Castle Attacked
	void OnTriggerStay(Collider collider){
		if (!collider.CompareTag ("Arrow")) {
			return;
		}else if (collider.CompareTag("Enemy1")){
			DealDamage (1);
			StartCoroutine (timer ());

		}else if (collider.CompareTag("Enemy2")){
			DealDamage (2);
			StartCoroutine (timer ());

		}else if (collider.CompareTag("Enemy3")){
			DealDamage (5);
			StartCoroutine (timer ());

		}else{
			DealDamage (10);
			StartCoroutine (timer ());
		}
	}

	private IEnumerator timer(){
		yield return new WaitForSeconds (1);
	}

	public void DealDamage(float damageValue){
		CurrentHealth -= damageValue;
		CastleHealthBar.value = CalculateHealth ();
		if (CurrentHealth <= 0) {
			GameOver ();
		}
	}

	public void GainHealth(float gainValue){
		Debug.Log ("Gaining Health: " + CurrentHealth);
		CurrentHealth += gainValue;
		CastleHealthBar.value = CalculateHealth ();
	}

	float CalculateHealth(){
		return CurrentHealth / MaxHealth;
	}
	void GameOver(){
		CurrentHealth = 0;
		Debug.Log ("Suohi Legion Took Over the Castle....You're now a SUOHI FOOTMAN.");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHealth : MonoBehaviour {

	public class HealthManager{
		public float CurrentHealth;
		public HealthManager(float health){
			CurrentHealth = health;
		}
	}

	private static float MaxHealth;
	public static HealthManager myHealth;

	// Use this for initialization
	void Start () {
		MaxHealth = 100f;
		myHealth = new HealthManager(MaxHealth);
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
			DealDamage (1f);
			StartCoroutine (timer ());

		}else if (collider.CompareTag("Enemy2")){
			DealDamage (2f);
			StartCoroutine (timer ());

		}else if (collider.CompareTag("Enemy3")){
			DealDamage (5f);
			StartCoroutine (timer ());

		}else{
			DealDamage (10f);
			StartCoroutine (timer ());
		}
	}

	private IEnumerator timer(){
		yield return new WaitForSeconds (1);
	}

	public static void DealDamage(float damageValue){
		myHealth.CurrentHealth -= damageValue;
		if (myHealth.CurrentHealth <= 0) {
			GameOver ();
		}
		Debug.Log ("Losing Health: " + myHealth.CurrentHealth);
	}

	public static void GainHealth(float gainValue){
		myHealth.CurrentHealth += gainValue;
		Debug.Log ("Gaining Health: " + myHealth.CurrentHealth);
	}

	public static float CalculateHealth(){
		return myHealth.CurrentHealth / MaxHealth;
	}
	private static void GameOver(){
		myHealth.CurrentHealth = 0;
		Debug.Log ("Suohi Legion Took Over the Castle....You're now a SUOHI FOOTMAN.");
	}
}

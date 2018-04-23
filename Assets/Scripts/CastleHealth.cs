using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHealth : MonoBehaviour {
	public AudioSource end;
	public AudioClip lose;
	public AudioClip win;
	public AudioClip start;
	public static int isEnded;
	private static float MaxHealth;
	public static float currentHealthLevel;
	public static HealthManager myHealth;


	public class HealthManager{
		public float CurrentHealth;
		public HealthManager(float health){
			CurrentHealth = health;
		}
	}
		
	// Use this for initialization
	void Start () {
		isEnded = 0;
		MaxHealth = 100f;
		currentHealthLevel = MaxHealth;
		myHealth = new HealthManager(MaxHealth);
		end.Play();
	}
		

	// Update is called once per frame
	void Update () {
		if (myHealth.CurrentHealth <= 0 && isEnded == 0) {
			GameOver ();
		} else if (isEnded == 1) {
			playWiningMusic ();
		}
	}

	private void playWiningMusic(){
		isEnded = 2;
		end.clip = win;
		end.Play ();
	}

	private IEnumerator timer(){
		yield return new WaitForSeconds (1);
	}

	public static void DealDamage(float damageValue){
		myHealth.CurrentHealth -= damageValue;
		Debug.Log ("Losing Health: " + myHealth.CurrentHealth);
	}

	public static void GainHealth(float gainValue){
		myHealth.CurrentHealth += gainValue;
		Debug.Log ("Gaining Health: " + myHealth.CurrentHealth);
	}

	public static float CalculateHealth(){
		currentHealthLevel = myHealth.CurrentHealth;
		return myHealth.CurrentHealth / MaxHealth;
	}

	private void GameOver(){
		isEnded = 2;
		end.clip = lose;
		end.Play ();
		Debug.Log ("Suohi Legion Took Over the Castle....You're now a SUOHI FOOTMAN.");
	}
		
}

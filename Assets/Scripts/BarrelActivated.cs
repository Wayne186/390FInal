using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BarrelActivated : MonoBehaviour {
	public static Boolean activated;
	private static Collider b_Collider;
	// Use this for initialization
	void Start () {
		activated = false;
		b_Collider = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (activated == true) {
			timer ();
		}
	}

	//Cause damage to castle
	void OnTriggerEnter(Collider collider){
		Debug.Log ("Gate Trap activated");
		if (activated == true) {
			if(!collider.CompareTag ("Gate")){
				return;
			}else{
				CastleHealth.DealDamage (5f);
			}
		}
	}

	//activated the barrel trap collider
	public static void Activated(){
		Debug.Log ("Barrel Trap set active");
		activated = true; 
		b_Collider.enabled = true;
	}

	//disable the barrel collider after 1 second.
	private IEnumerator timer(){
		activated = false;
		Debug.Log ("disbling collider...");
		yield return new WaitForSeconds (1);
		b_Collider.enabled = false;
	}
}

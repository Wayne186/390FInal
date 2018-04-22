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
	}
	
	// Update is called once per frame
	void Update () {
		if (activated == true) {
			StartCoroutine (timer ());
		}
	}

	//activated the barrel trap collider
	public static void Activated(GameObject currentObject){
		activated = true;
		b_Collider = currentObject.GetComponent<Collider> ();
		Debug.Log ("Barrel Trap Activated");
		if (currentObject.name == "BT3") {
			CastleHealth.DealDamage (5f);
		}
	}

	//disable the barrel collider after 1 second.
	public IEnumerator timer(){
		yield return new WaitForSeconds (1);
		activated = false;
		b_Collider.enabled = false;
		b_Collider.isTrigger = false;
		Debug.Log ("disbling collider..." + "Collider Status: " + b_Collider.enabled + " | Trigger Status: " + b_Collider.isTrigger);
	}
}

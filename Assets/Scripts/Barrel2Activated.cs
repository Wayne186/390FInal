using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Barrel2Activated : MonoBehaviour {
	public static Boolean activated;
	private static Collider b_Collider;
	int count = 0;

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
		b_Collider = currentObject.GetComponent<Collider> ();
		b_Collider.enabled = true;
		activated = true;
	}

	void OnTriggerEnter(Collider col) {
		Debug.Log ("Enter Explosion");
		Debug.Log (col);
		if(col.tag == "Body")
		{
			Debug.Log ("Exploded");
			SpawnManager.Instance.DamageEnemy (
				col.gameObject.transform.parent.gameObject.GetComponent<EnemyStatus>(), 3
			);
		}
	}

	//disable the barrel collider after 1 second.
	public IEnumerator timer(){
		if (activated == true) {
			yield return new WaitForSeconds (1);
			b_Collider.enabled = false;
			b_Collider.isTrigger = false;
			count++;
		}
		activated = false;
	}
}

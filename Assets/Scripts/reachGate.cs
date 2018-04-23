using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reachGate : MonoBehaviour {
	
	void OnTriggerEnter(Collider col) {
		Debug.Log ("Attack Collider" + col);
		if (col.tag == "Attack") {
			Debug.Log ("in Attack");
			Debug.Log (col.gameObject.transform.parent.gameObject);
			SpawnManager.Instance.enemyAttack (
				col.gameObject.transform.parent.gameObject.GetComponent<EnemyStatus> ()
			);
		}
	}
}

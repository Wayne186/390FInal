using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		Debug.Log (col);
		if(col.tag == "TrapCollider")
		{
			Debug.Log ("Zha ni ma b");
			//Debug.Log (col.gameObject.transform.parent.gameObject);
			SpawnManager.Instance.DamageEnemy (
				this.gameObject.transform.parent.gameObject.GetComponent<EnemyStatus>(), 3
			);
		}
	}
}

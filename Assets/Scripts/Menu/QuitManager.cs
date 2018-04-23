using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitManager : MonoBehaviour {

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Arrow") {
			Debug.Log ("2.....");
		} 
	}
}

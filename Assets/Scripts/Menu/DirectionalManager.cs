using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionalManager : MonoBehaviour {
	public AudioSource button;
	public Button buttons;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Arrow") {
			Debug.Log ("entering next/prev.....");
			button.Play ();
			StartCoroutine (timer ());
			buttons.onClick.Invoke ();
		} 
	}

	private IEnumerator timer(){
		yield return new WaitForSeconds (0.5f);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitManager  : MonoBehaviour {
	public AudioSource button;
	public Button quitButton;
	public GameObject mainMenu;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Arrow") {
			Debug.Log ("entering quit.....");
			StartCoroutine (timer ());
			quitButton.onClick.Invoke ();
		} 
	}

	private IEnumerator timer(){
		yield return new WaitForSeconds (0.5f);
		button.Play ();
		mainMenu.SetActive (false);
	}
}

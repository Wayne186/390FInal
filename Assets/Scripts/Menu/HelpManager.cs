using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpManager  : MonoBehaviour {
	public AudioSource button;
	public Button helpButton;
	public GameObject mainMenu;
	public GameObject backCollider;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Arrow") {
			Debug.Log ("entering help.....");
			button.Play ();
			StartCoroutine (timer ());
			helpButton.onClick.Invoke ();
		} 
	}

	private IEnumerator timer(){
		yield return new WaitForSeconds (0.5f);
		mainMenu.SetActive (false);
		backCollider.SetActive (true);
	}
}

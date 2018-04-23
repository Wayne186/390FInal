using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackManager : MonoBehaviour {
	public AudioSource button;
	public Button backButton;
	public GameObject mainMenu;
	public GameObject backCollider;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Arrow") {
			Debug.Log ("entering back.....");
			button.Play ();
			StartCoroutine (timer ());
			backButton.onClick.Invoke ();
		} 
	}

	private IEnumerator timer(){
		yield return new WaitForSeconds (0.5f);
		mainMenu.SetActive (true);
		backCollider.SetActive (false);
	}
}

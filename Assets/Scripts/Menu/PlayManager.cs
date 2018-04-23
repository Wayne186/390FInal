using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour {
	public AudioSource button;
	public Button playButton;
	public GameObject mainMenu;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Arrow") {
			Debug.Log ("entering play.....");
			StartCoroutine (timer ());
			playButton.onClick.Invoke ();
		} 
	}

	private IEnumerator timer(){
		yield return new WaitForSeconds (0.5f);
		button.Play ();
		mainMenu.SetActive (false);
	}
}

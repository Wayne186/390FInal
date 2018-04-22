using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelManager : MonoBehaviour {
	public ParticleSystem explosionLauncher;
	public List<GameObject> barrels;
	public Transform Trap;
	public GameObject Parent;
	public AudioClip FireBarrel;
	public AudioSource Explosion;

	// Use this for initialization
	void Start () {
		explosionLauncher.Stop ();
		Explosion.clip = FireBarrel;
		foreach (Transform child in Trap) {
			if(!child.gameObject.CompareTag("Fire")){
				barrels.Add(child.gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collider){
//		Debug.LogError ("entering barrel trap");
		if (!collider.CompareTag ("Arrow")) {
			return;
		} else {
			explosionLauncher.Play ();
			Explosion.Play ();
			StartCoroutine (timer ());
		}
	}

	private IEnumerator timer(){
		foreach (GameObject barrel in barrels) {
			Destroy (barrel);
		}
		yield return new WaitForSeconds (1);
		explosionLauncher.Stop ();
		BarrelActivated.Activated ();
		Destroy (Parent);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthParticle : MonoBehaviour {
	//public ParticleSystem explosionLauncher;
	public List<GameObject> particleChildren;
	public Transform Emission;
	public GameObject Parent;
	GameObject healthObject;
	public AudioSource Shoot;
	public float hp;
	CastleHealth healthManager;

	// Use this for initialization
	void Start () {
		foreach (Transform child in Emission) {
			if (!child.gameObject.CompareTag ("ParticleAudio")) {
				particleChildren.Add (child.gameObject);
			} 
		}
		healthManager = GetComponent<CastleHealth> ();
		hp = 2;

	}

	// Update is called once per frame
	void Update () {
		haha ();
	}

	void OnTriggerEnter(Collider collider){
		Debug.Log ("entering health particle");
		if (!collider.CompareTag ("Arrow")) {
			return;
		} else {
			//healthManager.GainHealth (hp);
			StartCoroutine (timer ());
		}
	}
	void haha(){
		StartCoroutine (timer ());
	}

	private IEnumerator timer(){
//		healthManager.GainHealth (hp);
		foreach (GameObject particle in particleChildren) {
			Destroy (particle);
		}
		Shoot.Play ();
		yield return new WaitForSeconds (2);
		Destroy (Parent);
	}
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthParticle : MonoBehaviour {
	public List<GameObject> particleChildren;
	public Transform Emission;
	public GameObject Parent;
	GameObject healthObject;
	public AudioSource Shoot;
	public float hp;

	// Use this for initialization
	void Start () {
		foreach (Transform child in Emission) {
			if (!child.gameObject.CompareTag ("ParticleAudio")) {
				particleChildren.Add (child.gameObject);
			} 
		}
		hp = 2f;
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider collider){
		Debug.Log ("entering health particle");
		if (!collider.CompareTag ("Arrow")) {
			return;
		} else {
			StartCoroutine (timer ());
		}
	}

	private IEnumerator timer(){
		CastleHealth.GainHealth (hp);
		foreach (GameObject particle in particleChildren) {
			Destroy (particle);
		}
		Shoot.Play ();
		yield return new WaitForSeconds (2);
		Destroy (Parent);
	}
		
}

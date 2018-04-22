using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointParticle : MonoBehaviour {
	//public ParticleSystem explosionLauncher;
	public List<GameObject> particleChildren;
	public Transform Emission;
	public GameObject Parent;
	public AudioSource Shoot;
	public float point;
	//PointManager pointManager;

	// Use this for initialization
	void Start () {
		foreach (Transform child in Emission) {
			if(!child.gameObject.CompareTag ("ParticleAudio")){
				particleChildren.Add(child.gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider collider){
		Debug.Log ("entering point particle");
		if (!collider.CompareTag ("Arrow")) {
			return;
		} else {
			StartCoroutine (timer ());
		}
	}

	private IEnumerator timer(){
		PointManager.GainPoints (point);
		foreach (GameObject particle in particleChildren) {
			Destroy (particle);
		}
		Shoot.Play();
		yield return new WaitForSeconds (2);
		Destroy (Parent);
	}
}

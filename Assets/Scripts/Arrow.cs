using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Arrow : MonoBehaviour {

	private bool isAttached = false;
	private bool isFired = false;
	public AudioSource Shot;

	void OnTriggerStay() {
		AttachArrow ();
	}

	void OnTriggerEnter(Collider col) {
		AttachArrow ();

		if (col.tag == "Body") {
			Debug.Log ("Body work");
			SpawnManager.Instance.DamageEnemy (
				col.gameObject.transform.parent.gameObject.GetComponent<EnemyStatus> (), 1
			);
			Destroy (this.gameObject);
		} else if (col.tag == "Head") {
			Debug.Log ("Head work");
			SpawnManager.Instance.DamageEnemy (
				col.gameObject.transform.parent.gameObject.GetComponent<EnemyStatus> (), 3
			);
			Destroy (this.gameObject);
		} else if(col.tag == "portbase"){
			Destroy (this.gameObject);
		}
	}

	void Update() {
		if (isFired && transform.GetComponent<Rigidbody> ().velocity.magnitude > 5f) {
			transform.LookAt (transform.position + transform.GetComponent<Rigidbody> ().velocity);
		}
	}

	public void Fired() {
		isFired =  true; 
		Shot.Play ();
	}

	private void AttachArrow() {
	/*	var device = SteamVR_Controller.Input((int)ArrowManager.Instance.trackedObj.index);
		if (!isAttached && device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			ArrowManager.Instance.AttachBowToArrow ();
			isAttached = true;
		}*/
	}


}

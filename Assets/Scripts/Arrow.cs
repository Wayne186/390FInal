using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Arrow : MonoBehaviour {

	private bool isAttached = false;

	private bool isShot = false;

	void OnTriggerStay() {
		AttachArrow ();
	}

	void OnTriggerEnter() {
		AttachArrow ();
	}

	void Update() {
		if (isShot && transform.GetComponent<Rigidbody> ().velocity.magnitude > 5f) {
			transform.LookAt (transform.position + transform.GetComponent<Rigidbody> ().velocity);
		}
	}

	public void Shot() {
		isShot =  true; 
	}

	private void AttachArrow() {
		var device = SteamVR_Controller.Input((int)ArrowManager.Instance.trackedObj.index);
		if (!isAttached && device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			ArrowManager.Instance.AttachBowToArrow ();
			isAttached = true;
		}
	}


}

﻿using UnityEngine;
using System;

public class MenuArrowManager : MonoBehaviour {

	public static MenuArrowManager Instance;

	public SteamVR_TrackedObject trackedObj;

	private GameObject currentArrow;

	public GameObject stringAttachPoint;
	public GameObject arrowStartPoint;
	public GameObject stringStartPoint;

	public GameObject arrowPrefab;

	private bool isAttached = false;

	void Awake() {
		if (Instance == null)
			Instance = this;
		GetComponent<StaffManager> ().enabled = false;
	}

	void OnDestroy() {
		if (Instance == this)
			Instance = null;
	} 

	// Use this for initialization
	void Start () {

	}


	void Update() {
		AttachArrow ();
		PullString ();
	}

	private void PullString() {
		if (isAttached) {
			float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;
			/*Debug.LogError (dist);
			dist = (float)Math.Exp ((double)(dist-1));
			Debug.LogError ("after expo :" + dist);*/
			stringAttachPoint.transform.localPosition = stringStartPoint.transform.localPosition  + new Vector3 (50f*dist, 0f, 0f);

			var device = SteamVR_Controller.Input((int)trackedObj.index);
			if (device.GetTouchUp (SteamVR_Controller.ButtonMask.Trigger)) {
				Fire ();
			}
		}
	}  

	private void Fire() {
		float dist = (stringStartPoint.transform.position - trackedObj.transform.position).magnitude;

		currentArrow.transform.parent = null;
		currentArrow.GetComponent<Arrow> ().Fired ();

		Rigidbody r = currentArrow.GetComponent<Rigidbody> ();
		r.velocity = currentArrow.transform.forward * 60f * dist*2;
		r.useGravity = true;

		currentArrow.GetComponent<Collider> ().isTrigger = false;

		stringAttachPoint.transform.position = stringStartPoint.transform.position;
		currentArrow = null;
		isAttached = false;
	}

	private void AttachArrow() {
		if (currentArrow == null) {
			currentArrow = Instantiate (arrowPrefab);
			currentArrow.transform.parent = trackedObj.transform;
			currentArrow.transform.localPosition = new Vector3 (0f, 0f, 0.6f);
			currentArrow.transform.localRotation = Quaternion.identity;
		}
	}

	public void AttachBowToArrow() {
		currentArrow.transform.parent = stringAttachPoint.transform;
		currentArrow.transform.position = arrowStartPoint.transform.position;
		currentArrow.transform.rotation = arrowStartPoint.transform.rotation;

		isAttached = true;
	} 
}

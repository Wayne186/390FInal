using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour {
	public class CurrentPointManager{
		public float CurrentPoint;
		public CurrentPointManager(float point){
			CurrentPoint = point;
		}
	}

	private static float MaxPoint;
	public static CurrentPointManager myPoint;

	void Start(){
		MaxPoint = 500f;
		myPoint = new CurrentPointManager(0);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			GainPoints (2);
		}
	}

	public static void GainPoints(float gainValue){
		Debug.Log ("Gaining " + gainValue + " points");
		myPoint.CurrentPoint += gainValue;
		Debug.Log ("Current Points: " + myPoint.CurrentPoint);
		if (myPoint.CurrentPoint == MaxPoint) {
			StaffActivated ();
		}
	}

	public static float CalculatePoint(){
		return myPoint.CurrentPoint / MaxPoint;
	}

	public static void StaffActivated(){
		Debug.Log ("Staff can be activate now.");
	}
}

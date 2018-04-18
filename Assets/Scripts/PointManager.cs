using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour {
	public static float CurrentPoint { get; set;}
	public static float MaxPoint { get; set; }
	public Slider PointBar;

	// Use this for initialization
	void Start () {
		MaxPoint = 150f;
		CurrentPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			GainPoints (2);
		}
	}

	public void GainPoints(float gainValue){
		CurrentPoint += gainValue;
		PointBar.value = CalculatePoint ();
		if (CurrentPoint == MaxPoint) {
			StaffActivated ();
		}
	}

	float CalculatePoint(){
		return CurrentPoint/ MaxPoint;
	}

	void StaffActivated(){
		Debug.Log ("Staff can be activate now.");
	}
}

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
	public static float myCurrentPoint;

	void Start(){
		MaxPoint = 500f;
		myPoint = new CurrentPointManager(0);
	}
	// Update is called once per frame
	void Update () {
		
	}

	public static void GainPoints(float gainValue){
		myPoint.CurrentPoint += gainValue;
		myCurrentPoint = myPoint.CurrentPoint;
	}

	public static void LostPoints(float lostValue){
		myPoint.CurrentPoint -= lostValue;
		myCurrentPoint = myPoint.CurrentPoint;
	}

	public static float CalculatePoint(){
		return myPoint.CurrentPoint / MaxPoint;
	}
}

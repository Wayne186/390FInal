using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointBarManager : MonoBehaviour {
	public Slider PointBar;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		PointBar.value = PointManager.CalculatePoint();
	}
}

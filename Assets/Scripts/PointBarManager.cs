using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointBarManager : MonoBehaviour {
	public Slider PointBar;
	public AudioSource levelup;
	private int up;
	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (PointManager.CalculatePoint () >= 150) {
			levelup.Play ();
			PointManager.LostPoints (150f);
		}
		PointBar.value = PointManager.CalculatePoint();
	}
}

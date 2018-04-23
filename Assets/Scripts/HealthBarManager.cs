using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour {
	public Slider CastleHealthBar;
	public Text record;

	// Use this for initialization
	void Start () {
		
	}

	// Update the current health value at health bar
	void Update () {
		record.text = "Castle Health: " + CastleHealth.currentHealthLevel + "/200";
		CastleHealthBar.value = CastleHealth.CalculateHealth ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour {
	public Slider CastleHealthBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update the current health value at health bar
	void Update () {
		CastleHealthBar.value = CastleHealth.CalculateHealth ();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDestination : MonoBehaviour {

	//1 for front, 2 for back, 3 for right, 4 for left
	public int up;
	public float right;
	public int back;
	public int rotate;


	private void OnTriggerEnter(Collider col)
	{
		//Debug.Log ("Collide");
		/*if(col.tag == "Enemy")
		{
			Vector3 direction;
			direction = new Vector3 (back, up, right);
			//levelManager.EnemyCrossed(1);
			SpawnManager.Instance.ChangeDirection(
				col.gameObject.GetComponent<EnemyStatus>(),
				direction, rotate
			);
		}*/
	}
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager> {

	public List<Transform> spawnPoint = new List<Transform>();
	public List<GameObject> spawnPrefabs = new List<GameObject>();
	private List<GameObject> activeEnemies = new List<GameObject>();

	public void Spawn(int spawnPrefabIndex)
	{
		Spawn(spawnPrefabIndex, 0);
	}

	public void Spawn(int spawnPrefabIndex, int spawnPointIndex) {
		GameObject go = Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation);
		activeEnemies.Add(go);
	}

	public void DestroyEnemy(GameObject go)
	{
		activeEnemies.Remove(go);
		Destroy(go, 5.0f);
	}

	/*
	public void ChangeDirection( EnemyStatus go, Vector3 direction, int rotationVector ) {
		go = (EnemyStatus)go;
		go.transform.rotation = Quaternion.AngleAxis(rotationVector, Vector3.up);
		go.ChangeDir (direction);
	}*/

	public void enemyAttack ( EnemyStatus go ) {
		go = (EnemyStatus)go;
		go.attackGate ();
	}

	public void DamageEnemy( EnemyStatus go, int damage ) {
		Debug.Log ("in spawn");
		go = (EnemyStatus)go;
		go.TakeDamage (damage);
	}

	public int GetEnemiesLeft()
	{
		return activeEnemies.Count;
	}

	public void Update()
	{

	}
}

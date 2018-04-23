using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyStatus : MonoBehaviour
{
	Animator anim;
	public float maxHealth;
	[System.NonSerialized]
	public float currentHealth;
	//public Vector3 dir;
	public RectTransform healthBar;
	public int healthBarSizeFactor;
	public int damage;
	NavMeshAgent agent;
	public GameObject particle;
	private bool dead;
	private GameObject currentParticle;
	private GameObject goal;
	public AudioSource Levels;
	public AudioClip start;
	public AudioClip hit;
	public AudioClip killed;
	bool isEnded;


	public void Start()
	{
		//this.dir = new Vector3(-1,0,0);
		isEnded =  true;
		if (CastleHealth.currentHealthLevel > 0) { 
			Levels.Play ();
		}
		anim = GetComponent<Animator>();
		dead = false;
		currentHealth = maxHealth;
		goal = GameObject.Find ("destination");
		agent = GetComponent<NavMeshAgent> ();
		agent.destination = goal.transform.position;
		healthBar.sizeDelta = new Vector2((currentHealth / maxHealth) * 50 * healthBarSizeFactor, healthBar.sizeDelta.y);
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		Debug.Log ("Take Damage");
		if (currentHealth <= 0 && dead == false)
		{
			Levels.clip = killed;
			Levels.Play ();
			dead = true;
			anim.SetTrigger ("isDead");
			//Debug.Log ("Take Damage!!" + amount);
			Destroy (agent);
			currentHealth = 0;
			currentParticle = Instantiate(particle);

			currentParticle.transform.position = this.gameObject.transform.position;
			SpawnManager.Instance.DestroyEnemy(gameObject);

		}
		healthBar.sizeDelta = new Vector2((currentHealth / maxHealth) * 50 * healthBarSizeFactor, healthBar.sizeDelta.y);
	}



	public void attackGate () {
		Destroy (agent);
		Levels.clip = hit;
		Levels.Play ();
		Debug.Log ("attackGate called, damage " + damage);
		anim.SetTrigger ("toAttack");
		InvokeRepeating ("doDamage", 2f, 2f);
	}

	void doDamage () {
		if (dead != true && isEnded == true) {
			Levels.Play ();
			CastleHealth.DealDamage (damage);
		}
	}
		
	public void Update()
	{
		if (CastleHealth.currentHealthLevel  <= 0 && isEnded == true) {
			Levels.Stop ();
			isEnded = false;
			Destroy (agent);
		}
	}
}
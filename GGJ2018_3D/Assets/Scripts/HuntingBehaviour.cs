using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingBehaviour : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public Animator animator;
	public float enemySpeed = 5;
	public float attackSpeed = 2;

	float timeCounter = 0;
	float attackCounter;

  public AudioClip[] AttackSounds;
	public Vector3 jump;
	public float jumpForce = 2.0f;

	public bool inDetectRange = false;
	public bool inAttackRange = false;

	private Vector3 wanderVector;

	Rigidbody rb;

	void Start () {
		player = GameObject.Find ("PlayerObject");
		rb = GetComponent<Rigidbody>();
		jump = new Vector3(0.0f, 2.0f, 0.0f);
		attackCounter = attackSpeed;

		wanderVector = Vector3.forward;
		wanderVector = Quaternion.Euler(Random.Range(0,360), 0, 0) * wanderVector;
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter++;
		Transform target = player.transform;
		float step = enemySpeed * (Time.deltaTime * (enemySpeed*2));

		//float distance = Vector3.Distance (transform.position, target.position);

    var soundInstance = SoundManager.instance;

		//Debug.Log("enemy distance: " + distance);
		if (inDetectRange) {
			if(inAttackRange)
			{
				animator.SetBool("attacking", true);

				attackCounter -= Time.deltaTime;
				if(attackCounter <= 0)
				{
					soundInstance.RandomizeSfx(soundInstance.AttackSounds, AttackSounds, 1);
					player.GetComponent<HitController>().takeHit();
					attackCounter = attackSpeed;
				}
			}
			else
			{
				animator.SetBool("attacking", false);

				transform.position = Vector3.MoveTowards (transform.position, target.position, step);
				attackCounter = attackSpeed;
			}
			
		}
		else
		{
			if(timeCounter > 100)
			{
				rb.AddForce(jump * jumpForce, ForceMode.Impulse);
				timeCounter = 0;
				// rigidbody.AddForce (up * 5, ForceMode.Impulse);

				wanderVector = Vector3.forward;
				wanderVector = Quaternion.Euler(Random.Range(0,360), 0, 0) * wanderVector;

			}

			transform.position += (wanderVector * step / 2);
		}
	}

	public void detectTriggerEnter(Collider other)
	{
		if(other.gameObject == player)
		{
			inDetectRange = true;
		}
	}

	public void detectTriggerExit(Collider other)
	{
		if(other.gameObject == player)
		{
			inDetectRange = false;
		}
	}

	public void attackTriggerEnter(Collider other)
	{
		if(other.gameObject == player)
		{
			inAttackRange = true;
		}
	}

	public void attackTriggerExit(Collider other)
	{
		if(other.gameObject == player)
		{
			inAttackRange = false;
		}
	}
}

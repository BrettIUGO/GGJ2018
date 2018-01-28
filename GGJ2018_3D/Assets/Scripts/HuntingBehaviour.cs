using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingBehaviour : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public Animator animator;
	public float enemySpeed = 5;
	float timeCounter = 0;
  public AudioClip[] AttackSounds;
	public Vector3 jump;
	public float jumpForce = 2.0f;

	public bool inDetectRange = false;
	public bool inAttackRange = false;

	Rigidbody rb;

	void Start () {
		player = GameObject.Find ("PlayerObject");
		rb = GetComponent<Rigidbody>();
		jump = new Vector3(0.0f, 2.0f, 0.0f);
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
			if(!inAttackRange)
				transform.position = Vector3.MoveTowards (transform.position, target.position, step);
			
			animator.SetBool("attacking", true);
      soundInstance.RandomizeSfx(soundInstance.AttackSounds, AttackSounds, 1);
		}
		else
		{
			animator.SetBool("attacking", false);

			if(timeCounter > 100)
			{
				rb.AddForce(jump * jumpForce, ForceMode.Impulse);
				timeCounter = 0;
				// rigidbody.AddForce (up * 5, ForceMode.Impulse);
			}
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

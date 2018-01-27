using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingBehaviour : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	public float enemySpeed = 2;

	void Start () {
		player = GameObject.Find ("PlayerObject");
	}
	
	// Update is called once per frame
	void Update () {

		Transform target = player.transform;
		float step = enemySpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		
	}
}

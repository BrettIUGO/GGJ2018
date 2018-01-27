﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public float delay = 1;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", delay, delay);
	}
	
	// Update is called once per frame
	void Spawn(){
		Instantiate (enemy, new Vector3 (Random.Range (10, 100), 3, Random.Range(10,100)), Quaternion.identity);
	}
}

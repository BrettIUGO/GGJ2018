using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public float delay = 1;
	public float minRange = 0f;
	public float maxRange = 100f;

	public GameObject spawnPoint;
	public GameObject enemy;
	public float time  = 0;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", delay, delay);
	}
	
	// Update is called once per frame
	void Update() {
		time++;
		if (time > 500) {
			CancelInvoke ();
		}
	}

	void Spawn(){
		Instantiate (enemy, spawnPoint.transform.position + new Vector3 (Random.Range (minRange, maxRange), 3, Random.Range(minRange,maxRange)), Quaternion.identity);
	}
}

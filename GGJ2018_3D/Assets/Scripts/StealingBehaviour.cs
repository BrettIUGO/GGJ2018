using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StealingBehaviour : MonoBehaviour {

	public float enemySpeed = 5;

	public float collectRange = 5f;
	public float collectForce = 5f;

	private GameObject player;
	
	private bool hasCollectable = false;

	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		float step = enemySpeed * (Time.deltaTime * (enemySpeed*2));

		if(hasCollectable) {
			Transform target = player.transform;

			var collectables = GameObject.FindGameObjectsWithTag("Collectable");
			var closestCollectable = collectables.OrderBy(collectable => Vector3.Distance(transform.position, collectable.transform.position)).FirstOrDefault();

			float distance = Vector3.Distance(closestCollectable.transform.position, transform.position);

			Vector3 move = transform.position - target.position;
			move.y = 0;
			move.Normalize();
			transform.Translate(move * enemySpeed * Time.deltaTime);

			if(distance >= collectRange) {
				hasCollectable = false;
			}

			if(distance < collectRange ) {
				Vector3 direction = transform.position - closestCollectable.transform.position ;
				closestCollectable.GetComponent<Rigidbody>().AddForce(direction.normalized * collectForce, ForceMode.Impulse);

				hasCollectable = true;
			}

		} else {			
			var collectables = GameObject.FindGameObjectsWithTag("Collectable");
			var closestCollectable = collectables.OrderBy(collectable => Vector3.Distance(transform.position, collectable.transform.position)).FirstOrDefault();
			transform.position = Vector3.MoveTowards (transform.position, closestCollectable.transform.position, step);

			float distance = Vector3.Distance(closestCollectable.transform.position, transform.position);

			if(distance < collectRange ) {
				Vector3 direction = transform.position - closestCollectable.transform.position ;
				closestCollectable.GetComponent<Rigidbody>().AddForce(direction.normalized * collectForce, ForceMode.Impulse);

				hasCollectable = true;
			}

		}
	}
}

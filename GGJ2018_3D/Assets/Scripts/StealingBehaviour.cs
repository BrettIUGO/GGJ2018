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
		Transform target = player.transform;
		if (Vector3.Distance(transform.position, target.position) > 100f) {
			return;
		}


		float step = enemySpeed * (Time.deltaTime * (enemySpeed*2));

		if(hasCollectable) {
			string[] tags = {"Collectable", "Junk"};

			var combinedList = new List<GameObject>();

			GameObject[] collectables = GameObject.FindGameObjectsWithTag("Collectable");
			GameObject[] junks = GameObject.FindGameObjectsWithTag("Junk");
			
			combinedList.AddRange(collectables);
			combinedList.AddRange(junks);

			var closestCollectable = combinedList.OrderBy(collectable => Vector3.Distance(transform.position, collectable.transform.position)).FirstOrDefault();

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
			var combinedList = new List<GameObject>();
			GameObject[] collectables = GameObject.FindGameObjectsWithTag("Collectable");
			GameObject[] junks = GameObject.FindGameObjectsWithTag("Junk");
			
			combinedList.AddRange(collectables);
			combinedList.AddRange(junks);

			var closestCollectable = combinedList.OrderBy(collectable => Vector3.Distance(transform.position, collectable.transform.position)).FirstOrDefault();
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

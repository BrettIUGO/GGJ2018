using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour {

	public float force = 1.0f;
	public float range = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire2")) {
			print("fire2");

			var collectables = GameObject.FindGameObjectsWithTag("Collectable");
			var junkCollectables = GameObject.FindGameObjectsWithTag("Junk");

			foreach(var collectable in collectables) {
				if(Vector3.Distance(collectable.transform.position, transform.position) < range) {
					Vector3 direction = collectable.transform.position - transform.position;
					collectable.GetComponent<Rigidbody>().AddForce(direction.normalized * force, ForceMode.Impulse);
				}
			}

			foreach(var collectable in junkCollectables) {
				if(Vector3.Distance(collectable.transform.position, transform.position) < range) {
					Vector3 direction = collectable.transform.position - transform.position;
					direction.y = 0;
					collectable.GetComponent<Rigidbody>().AddForce(direction.normalized * force, ForceMode.Impulse);
				}
			}
		}
	}
}

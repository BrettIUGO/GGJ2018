using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectTrigger : MonoBehaviour {

	private HuntingBehaviour hunter;

	// Use this for initialization
	void Start () {
		hunter = transform.parent.gameObject.GetComponent<HuntingBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		hunter.detectTriggerEnter(other);
	}

	void OnTriggerExit(Collider other)
	{
		hunter.detectTriggerExit(other);
	}
}

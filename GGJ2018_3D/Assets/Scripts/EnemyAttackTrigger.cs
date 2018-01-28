using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour {

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
		hunter.attackTriggerEnter(other);
	}

	void OnTriggerExit(Collider other)
	{
		hunter.attackTriggerExit(other);
	}
}

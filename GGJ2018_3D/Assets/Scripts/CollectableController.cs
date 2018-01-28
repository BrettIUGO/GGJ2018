using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour {

	public float collectTime = 3f;
	public string itemType = "metal";
	public int maxCollects = 1;

	public int amount = 1;

	protected float collectDuration = 0f;
	protected int currentCollects = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onTriggerEnter() {
		//collectStartTime = Time.time;
	}

	void OnTriggerStay () {
		collectDuration += Time.deltaTime;
		print(collectDuration);
		if(collectDuration > collectTime) {
			Collect();
			collectDuration = 0f;
		}

	}

	void OnTriggerExit(){
		collectDuration = 0f;
	}

	void Collect() {
		currentCollects += 1;
		print("collected " + amount + " " + itemType);
		PlayerStats.metal += amount;

		if(currentCollects >= maxCollects) {
			Destroy(gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableController : MonoBehaviour {

	public float collectTime = 3f;
	public string itemType = "metal";
	public int maxCollects = 1;

	public int amount = 1;

	protected float collectDuration = 0f;
	protected int currentCollects = 0;

	private GameObject coinText;
	// Use this for initialization
	void Awake () {
		coinText = GameObject.Find("CoinText");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onTriggerEnter() {
		//collectStartTime = Time.time;
	}

	void OnTriggerStay (Collider collision) {
		if(collision.tag == "Player") {

			collectDuration += Time.deltaTime;
			print(collectDuration);
			if(collectDuration > collectTime) {
				Collect();
				collectDuration = 0f;
			}
		}
	}

	void OnTriggerExit(){
		collectDuration = 0f;
	}

	void Collect() {
		currentCollects += 1;
		print("collected " + amount + " " + itemType);
		PlayerStats.metal += amount;
		PlayerStats.increaseCollectable(itemType, amount);
		//PlayerStats["metal"] += amount;


		coinText.GetComponent<Text>().text = (string)PlayerStats.getCollectableCount(itemType).ToString();
		



		if(currentCollects >= maxCollects) {
			Destroy(gameObject);
		}
	}
}

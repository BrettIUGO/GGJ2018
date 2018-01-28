using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour {

	GameObject healthSlider;

	// Use this for initialization
	void Awake () {
		healthSlider = GameObject.Find("HealthSlider");
		healthSlider.GetComponent<Slider>().value = 50;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Enemy") {
			PlayerStats.health -= 10;

			
			healthSlider.GetComponent<Slider>().value = PlayerStats.health;
		}
	}
}

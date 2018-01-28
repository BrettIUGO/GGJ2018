using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour {

	GameObject healthSlider;

  public AudioClip[] InjurySounds;

	// Use this for initialization
	void Awake () {
		healthSlider = GameObject.Find("HealthSlider");
		healthSlider.GetComponent<Slider>().value = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Enemy") {
			PlayerStats.health -= 10;

      if (InjurySounds.Length > 0)
      {
        SoundManager.instance.RandomizeSfx(InjurySounds);
      }

      healthSlider.GetComponent<Slider>().value = PlayerStats.health;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour {

	GameObject healthSlider;

  public AudioClip[] InjurySounds;
  public AudioClip DeathSound;

	// Use this for initialization
	void Awake () {
		healthSlider = GameObject.Find("HealthSlider");
		healthSlider.GetComponent<Slider>().value = PlayerStats.health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
  {
		if (collision.gameObject.tag == "Enemy")
    {
      PlayerStats.health -= 10;

      var soundInstance = SoundManager.instance;

      if (PlayerStats.health > 0)
      {
        soundInstance.RandomizeSfx(soundInstance.FXSource, InjurySounds);
      }
      else
      {
        soundInstance.PlaySingle(soundInstance.FXSource, DeathSound);
        //MIKE TODO: trigger game over state here!
      }



      healthSlider.GetComponent<Slider>().value = PlayerStats.health;
		}
	}
}

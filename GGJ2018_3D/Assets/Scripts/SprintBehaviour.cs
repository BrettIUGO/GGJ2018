using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintBehaviour : MonoBehaviour {

	float sprintEnergy = 100f;
	float maxSprintEnergy = 100f;
	float sprintModifier = .6f;
	float sprintConsumptionRate = 1.6f;
	float sprintRecoveraryRate = 0.4f;
	MovementController movementController;

	// Use this for initialization
	void Start () {
		movementController = gameObject.GetComponent<MovementController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Sprint:" +sprintEnergy);

		if ((Input.GetKey (KeyCode.LeftShift) || Input.GetAxis ("Sprint") > 0) && sprintEnergy > 0) {
			movementController.movementModifier = sprintModifier;
			sprintEnergy-= sprintConsumptionRate;
		} else {
			movementController.movementModifier = movementController.defaultMovementModifier;
			if (sprintEnergy < maxSprintEnergy) {
				sprintEnergy+= sprintRecoveraryRate;
			}
		}

		Slider collectSlider = GameObject.Find("SprintSlider").GetComponent<Slider>();

		if (collectSlider != null) {
			collectSlider.value = sprintEnergy;
		} else {
			//Debug.Log ("help");
		}
	}
}

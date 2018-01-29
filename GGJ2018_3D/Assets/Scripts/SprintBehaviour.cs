using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintBehaviour : MonoBehaviour {

	public float sprintEnergy = 100f;
	public float maxSprintEnergy = 100f;
	public float sprintModifier = .6f;
	public float sprintConsumptionRate = 50f;
	public float sprintRecoveryRate = 25f;
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
			sprintEnergy -= sprintConsumptionRate * Time.deltaTime;
		} else {
			movementController.movementModifier = movementController.defaultMovementModifier;
			if (sprintEnergy < maxSprintEnergy) {
				sprintEnergy += sprintRecoveryRate * Time.deltaTime;
			}
		}

		var sprintSlider = GameObject.Find ("SprintSlider");
		if (sprintSlider != null) {

			Slider collectSlider = sprintSlider.GetComponent<Slider>();

			if (collectSlider != null) {
				collectSlider.value = sprintEnergy;
			} else {
				//Debug.Log ("help");
			}
		}
	}
}

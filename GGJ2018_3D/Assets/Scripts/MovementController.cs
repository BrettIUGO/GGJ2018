using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	float rotateSpeed = 7.5f;

	float x;
	float z;
	float rx;
	float ry;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		x = Input.GetAxis ("Horizontal") * 0.25f;
		z = Input.GetAxis ("Vertical") * 0.5f;
		rx = Input.GetAxis ("JoyR X");

		transform.Translate(x, 0, z);
		if (Input.GetKey (KeyCode.Q)) {
			transform.Rotate (-Vector3.up * rotateSpeed);
		} else if (Input.GetKey(KeyCode.E)) {
			transform.Rotate(Vector3.up * rotateSpeed);
		}

		transform.Rotate (new Vector3(0, rx, 0) * rotateSpeed);
	}
}

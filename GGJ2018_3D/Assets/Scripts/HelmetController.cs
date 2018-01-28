using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetController : MonoBehaviour {

	public GameObject mainCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			Debug.Log("Pressed fire");

			mainCamera.GetComponent<Camera>().cullingMask ^= (1 << 8);
		}

	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public Transform lookAt;

	
	// Update is called once per frame
	void Update () {
		if(!lookAt) {
			lookAt = GameObject.FindGameObjectWithTag("Player").transform;
		}

		transform.LookAt(lookAt);
	}
}

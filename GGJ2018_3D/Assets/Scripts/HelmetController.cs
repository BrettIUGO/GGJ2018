using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetController : MonoBehaviour {

	public GameObject mainCamera;

	public SpriteRenderer spriteRenderer;
	public Sprite spriteMode1;
	public Sprite spriteMode2;

	public bool helmetOn;

	// Use this for initialization
	void Start () {
		helmetOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			Debug.Log("Pressed fire");

			helmetOn = !helmetOn;

			if(helmetOn)
			{
				mainCamera.GetComponent<Camera>().cullingMask |= (1 << 8);
				spriteRenderer.sprite = spriteMode2;
			}
			else
			{
				mainCamera.GetComponent<Camera>().cullingMask &= ~(1 << 8);
				spriteRenderer.sprite = spriteMode1;
			}
		}

	}
}

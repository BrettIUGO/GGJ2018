using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HelmetController : MonoBehaviour {

	public GameObject mainCamera;

	public SpriteRenderer spriteRenderer;
	public Sprite spriteMode1;
	public Sprite spriteMode2;

	public bool helmetOn;

	public float maxDistance = 100f;

	Slider collectSlider;

	public Animator animator;
	// Use this for initialization
	void Awake () {
		helmetOn = false;
		collectSlider = GameObject.Find("CollectSlider").GetComponent<Slider>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			//Debug.Log("Pressed fire");

			helmetOn = !helmetOn;

			if(helmetOn)
			{
				mainCamera.GetComponent<Camera>().cullingMask |= (1 << 8);
				spriteRenderer.sprite = spriteMode2;

				animator.SetBool("glowing", true);
				AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);        	
				if (animationState.IsName("walkAnim")) {
					var fadeTime = (animationState.normalizedTime % 1);
					animator.CrossFade("GlowWalk", 0f, 0, fadeTime);
				}
			}
			else
			{
				mainCamera.GetComponent<Camera>().cullingMask &= ~(1 << 8);
				spriteRenderer.sprite = spriteMode1;
				animator.SetBool("glowing", false);
				AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
				if (animationState.IsName("GlowWalk")) {
					var fadeTime = (animationState.normalizedTime % 1);
					animator.CrossFade("walkAnim", 0f, 0, fadeTime);
				}
			}
		}

		if(!helmetOn) {
			//Show slider
			var collectables = GameObject.FindGameObjectsWithTag("Collectable");
			var closestCollectable = collectables.OrderBy(collectable => Vector3.Distance(transform.position, collectable.transform.position)).FirstOrDefault();

			collectSlider.value = Mathf.Lerp(collectSlider.value, maxDistance - Vector3.Distance(closestCollectable.transform.position, transform.position), 0.1f);
		} else {
			//Hide slider
			collectSlider.value = Mathf.Lerp(collectSlider.value, 0f, 0.1f);
		}

	}
}

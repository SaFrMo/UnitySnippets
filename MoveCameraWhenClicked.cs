using UnityEngine;
using System.Collections;
using System;

public class MoveCameraWhenClicked : MonoBehaviour {
	
	// place this on an object that, when clicked, changes the camera position.
	// smoothly transition to pos2 at rate.
	
	public GameObject pos2;
	
	public float rate = 10f;
	
	bool moving = false;

	void OnMouseOver () {
		if (Input.GetMouseButtonDown(0)) {
			moving = true;
		}
	}
	
	void Update () {
		if (moving) {
			Vector3 currentPos = Camera.main.transform.position;
			Vector3 nextPos = Vector3.Lerp (currentPos, pos2.transform.position, Time.deltaTime * rate);
			Camera.main.transform.position = nextPos;
		}
		// prevents asymptotic movement
		if (Math.Abs(Camera.main.transform.position.x - pos2.transform.position.x) <= 0.01f) {
			Camera.main.transform.position = pos2.transform.position;
			moving = false;
		}
	}
}

using UnityEngine;
using System.Collections;

public class PlatformerMovement : MonoBehaviour {

	// default controls, where applicable
	protected KeyCode jump = KeyCode.Space;

	// default movement rates
	protected float movementRate = 0.15f;
	protected float jumpRate = 6f;

	// basic movement
	protected void LRMove () {
		rigidbody.MovePosition (transform.position + Vector3.right * Input.GetAxis("Horizontal") * movementRate);
	}

	protected void Jump () {
		if (Input.GetKeyDown (jump)) {
			rigidbody.AddForce (Vector3.up * jumpRate, ForceMode.Impulse);
		}
	}

	// called on each frame
	protected void Update () {
		LRMove();
		Jump ();
	}
}

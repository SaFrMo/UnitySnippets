﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class WASDMovement : MonoBehaviour {

	// IMPLEMENTATION
	// ===================
	// Attach to an object that needs WASD to move.
	// Edit controls in Controls() below as fit.

	// rate at which to move
	public float movementRate = 0.5f;

	// where the rigidbody will move
	Vector3 newPosition;

	// MOVEMENT COMPONENT
	// ====================
	// Called for each possible control. Result is added to transform.position
	// to produce accurate movement.

	protected Vector3 SingleControl(KeyCode key, Vector3 direction) {
		if (Input.GetKey (key)) {
			return direction * movementRate;
		}
		else {
			return Vector3.zero;
		}
	}

	// MAIN CONTROLS
	// ====================
	// Runs all Single Controls and generates a new Vector3 based on the results,
	// then uses the rigidbody (so as to detect collisions) to move the GO to that
	// new position.

	protected void Controls() {
		newPosition = transform.position +
			SingleControl (KeyCode.W, Vector3.up) +
			SingleControl (KeyCode.A, Vector3.left) +
			SingleControl (KeyCode.S, Vector3.down) +
			SingleControl (KeyCode.D, Vector3.right);
		rigidbody.MovePosition (newPosition);
	}


	protected void Update () {
		Controls();
	}
}

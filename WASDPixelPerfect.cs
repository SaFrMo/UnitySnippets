using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WASDPixelPerfect : MonoBehaviour {
	
	/*
	 * FIELDS
	 */
	
	// player sprite
	public GameObject sprite;
	
	// starting stats - magic numbers, CAN
	public float movementRate = 5f;
	
	// movement controls
	public Dictionary<KeyCode, Vector3> controlsMovement;
	KeyCode upKey = KeyCode.W;
	KeyCode downKey = KeyCode.S;
	KeyCode leftKey = KeyCode.A;
	KeyCode rightKey = KeyCode.D;
	
	/*
	 * METHODS
	 */
	
	// shortcut for movement controls
	void Move (KeyCode k, Vector3 v) {
		if (Input.GetKey (k))
			sprite.transform.position = sprite.transform.position + (v * movementRate);
	}
	
	void Controls () {
		foreach (var c in controlsMovement)
			Move (c.Key, c.Value);
	}
	
	/*
	 * MAKIN' IT HAPPEN
	 */
	
	void Start() {
		controlsMovement = new Dictionary<KeyCode, Vector3>() {
			{ upKey, Vector3.up },
			{ downKey, Vector3.down },
			{ leftKey, Vector3.left },
			{ rightKey, Vector3.right }
		};
	}
	
	void FixedUpdate () {
		Controls();
	}
	
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class WASDPixelPerfect : MonoBehaviour {

	// Updated to use Rigidbody physics!
	
	/*
	 * FIELDS
	 */
	
	// starting stats - magic number, CAN CHANGE.
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
			rigidbody.MovePosition (gameObject.transform.position + (v * movementRate));
		print (k);
		print (v);
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

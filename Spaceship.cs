using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Spaceship : MonoBehaviour {
	
	
	
	
	
	
	// FIELDS
	
	/*
	 * OPTIONS
	 */
	
	public bool usesFuel = true;
	public bool usesHP = true;
	
	
	/*
	 * CONTROLS
	 */
	
	KeyCode throttleKey = KeyCode.Space;
	KeyCode rotateClockwise = KeyCode.A;
	KeyCode rotateCounterClockwise = KeyCode.D;
	
	
	/*
	 * STATS (visible to player)
	 */
	
	public int Fuel { get; private set; }
	public float Velocity { get; private set; }
	public bool ThrottleOn { get; private set; }
	public int HP { get; private set; }
	
	
	/*
	 * STATS (for editor use)
	 */
	
	public float ThrottleMultiplier { get; private set; }
	public float RotationMultiplier { get; private set; }
	public bool Destroyed { get; private set; }
	
	
	/*
	 * DEFAULT VALUES
	 */
	
	// These are magic numbers - replace as necessary
	public int startingFuel = 1138;
	public float startingThrottleMultiplier = 47;
	public float startingRotationMultiplier = 42;
	public int startingHP = 314;
	
	
	
	
	
	
	
	
	// METHODS
	
	// appropriate fields are initialized with default values. This is called at Start()
	void SetDefaultValues () {
		Fuel = startingFuel;
		ThrottleMultiplier = startingThrottleMultiplier;
		RotationMultiplier = startingRotationMultiplier;
		HP = startingHP;
	}
	
	/*
	 * CONTROLS
	 */

	void Controls () {
		
		// THROTTLE
		if (Input.GetKey (throttleKey)) {
			// checks fuel if ship uses fuel, bypasses this step if ship doesn't use fuel
			if ((usesFuel && Fuel > 0) || !usesFuel) {
				ThrottleOn = true;
				rigidbody.AddRelativeForce (Vector3.up * ThrottleMultiplier);
				// decrement fuel if appropriate
				if (usesFuel) {
					Fuel--;
				}
			}
		}
		else {
			ThrottleOn = false;
		}
		
		// ROTATION
		if (Input.GetKey (rotateClockwise)) {
			transform.Rotate (Vector3.forward * Time.deltaTime * RotationMultiplier);
		}
		if (Input.GetKey (rotateCounterClockwise)) {
			transform.Rotate (Vector3.back * Time.deltaTime * RotationMultiplier);
		}
	}
	
	/*
	 * CALCULATE STATS
	 */
	
	void CalculateVelocity () {
		Velocity = rigidbody.velocity.magnitude;
	}
	
	/*
	 * DESTROY SHIP
	 */
	
	void ShipDestroyed () {
		// only trigger if "Uses HP" is checked
		if (usesHP && HP <= 0) {
			Destroyed = true;
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	// MAKIN' IT HAPPEN
	void Start () {
		SetDefaultValues();
	}
	
	void FixedUpdate () {
		Controls();
	}
	
	void Update () {
		CalculateVelocity();
		ShipDestroyed();
	}
	
	
}

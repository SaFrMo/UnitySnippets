using UnityEngine;
using System.Collections;

public class ScriptedActions : MonoBehaviour {

	/*
	 * FIELDS
	 */
	
	// are the one-off events complete?
	bool oneOffsComplete = false;
	// current step
	int current = 0;
	
	/*
	 * METHODS
	 */
	
	// the scripted actions of the scene
	void UpdateScene() {
		
		switch (current) {
			
		case 0:
			
			break;
		};
	}
	
	// resets "one-offs" flag and advances a step
	void Advance () {
		oneOffsComplete = false;
		current++;
	}
	
	/*
	 * MAKIN' IT HAPPEN
	 */
	
	void Update() {
		UpdateScene();
	}
	
}

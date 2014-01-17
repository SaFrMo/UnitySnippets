using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	// Generic class for an in-game, clickable menu
	
	// CLICKABLE BUTTONS MUST:
	/* Have a collider
	 * Have a rigidbody
	 */
	
	// __________________________________________________________ STEP 1
	// LIST OF ALL BUTTONS HERE
	public string button1Name;
	
	
	
	void OnMouseDown () {
		Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit rHit;
		
		// must click on something with a collider
		if (!Physics.Raycast (r, out rHit)) {
			return;
		}
		
		// ______________________________________________________ STEP 2
		// Copy and paste this; replace "button1Name" as needed
		
		if (rHit.transform.name == button1Name) {
			
		}
		
		// ________________________________________________________ DONE
	}
}

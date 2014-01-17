using UnityEngine;
using System.Collections;

public class NameEntry : MonoBehaviour {

	string playerName = string.Empty;
	
	
	/*
	 * METHODS
	 */
	
	// call OnGUI
	void FirstScreen () {
		int boxWidth = 200;
		int boxHeight = 25;
		GUI.Box (new Rect (
			Screen.width / 2 - boxWidth / 2, 
			Screen.height / 2 - boxHeight, 
			boxWidth, 
			boxHeight),
			"Enter your name:");
        playerName = GUI.TextField(new Rect(
			Screen.width / 2 - boxWidth / 2, 
			Screen.height / 2, 
			boxWidth, 
			boxHeight),
			playerName, 25);
		if (Event.current.isKey && Event.current.keyCode == KeyCode.Return) {
			// what to do when "enter" or "OK" are pressed
		}
	}
}

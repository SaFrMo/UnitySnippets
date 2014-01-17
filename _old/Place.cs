using UnityEngine;
using System.Collections;

// PROPORTIONAL SIZER AND PLACER.

// Assumes a 2D game. 








public class Place : MonoBehaviour {
	
	public float xSize;
	public float ySize;
	
	public float xPos;
	public float yPos;
	
	
	/*public Place (GameObject go, float xPos, float yPos, float xSize, float ySize, string name) {
		Finalize (go, 
			ResizeProportionally ( xSize, ySize ),
			PlaceProportionally (xPos, yPos, WholeScreen(), go));
	}*/
	
	// space between created objects
	public float spacer = 0.01f;
	
	// grabs the current screen resolution 
	Vector3 WholeScreen () {
		float height = Camera.main.orthographicSize * 2;
		float width = height * Screen.width / Screen.height;
		return new Vector3 (width, height, 1);
	}
	
	// user enters percentage of screen size; function returns actual pixel size
	Vector3 ResizeProportionally (float x, float y) {
		Vector3 temp = WholeScreen();
		Vector3 result = new Vector3 (temp.x * x, temp.y * y, temp.z);
		return result;
	}
	
	// where screen's top-left is (0, 0) and lower-right is (1, 1)
	// places {go} at {x, y}, where x and y are percentages of screen size
	// anchor point is upper left corner of {go}
	Vector3 PlaceProportionally (float x, float y, Vector3 screenSize, GameObject go) {
		Vector3 zeroPoint = new Vector3 (
			-screenSize.x / 2f,
			screenSize.y / 2f,
			1);
		Vector3 result = new Vector3 (
			screenSize.x * x + zeroPoint.x + go.collider.bounds.extents.x,
			-screenSize.y * y + zeroPoint.y - go.collider.bounds.extents.y,
			1);
		return result;
	}

	
	public void Finalize (GameObject go, Vector3 size, Vector3 location) {
		go.transform.localPosition = location;
		go.transform.localScale = size;
	}

	/*void FactoryCreate (GameObject go, float x, float y, float sizeX, float sizeY) {
		
	}
	*/

	
	// Contains all the magic numbers for gameplay screen sizes
	/*void Update () {
		
		FactoryCreate (mainspringBin, 0, 0, .375f, .3f);
		
		FactoryCreate (rejectBin, .375f + spacer, 0, .25f, .3f);
		
		// call spacer twice because value is already offset by spacer once
		FactoryCreate (balanceWheelBin, .625f + spacer + spacer, 0, .375f, .3f);
		
		// middle row: conveyor belt
		FactoryCreate (conveyorBelt, -1f, .3f + spacer, 3f, .3f - spacer);
		
		// bottom row
		FactoryCreate (gearBin, 0f, .6f + spacer, .375f, .4f);
		
		FactoryCreate (table, .375f + spacer, .6f + spacer, .25f, .3f);
		
		FactoryCreate (indicatorBin, .625f + spacer + spacer, .6f + spacer, .375f, .4f);
		
		// offscreen
		//FactoryCreate (watchSpawner, 0, .4f, .1f, .1f);
		
		
		
		
	}*/

	void Update () {
		Finalize (gameObject, 
			ResizeProportionally ( xSize, ySize ),
			PlaceProportionally (xPos, yPos, WholeScreen(), gameObject));
	}
}

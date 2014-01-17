using UnityEngine;
using System.Collections;

// PROPORTIONAL SIZER AND PLACER.

// Assumes a 2D game. 

// USE: Call 
public static class Place : MonoBehaviour {

	
	
	// space between created objects
	public float SPACER = 0.01f;
	
	// grabs the current screen resolution 
	Vector3 WholeScreen () {
		float height = Camera.main.orthographicSize * 2;
		float width = height * Screen.width / Screen.height;
		return new Vector3 (width, height, 1);
	}
	
	Vector3 ResizeProportionally (float x, float y) {
		Vector3 temp = WholeScreen();
		Vector3 result = new Vector3 (temp.x * x, temp.y * y, temp.z);
		return result;
	}
	
	Vector3 PlaceProportionally (float x, float y, Vector3 screenSize, Collider c) {
		Vector3 zeroPoint = new Vector3 (
			-screenSize.x / 2f,
			screenSize.y / 2f,
			1);
		Vector3 result = new Vector3 (
			screenSize.x * x + zeroPoint.x + c.bounds.extents.x,
			-screenSize.y * y + zeroPoint.y - c.bounds.extents.y,
			1);
		
			
			
			
		return result;
	}
	
	
	
	
	void CreateObject (string name, Material objectMaterial, float xSize, float ySize, Vector3 location) {
		GameObject created = GameObject.CreatePrimitive(PrimitiveType.Cube);
		created.name = name;
		created.transform.position = location;
		created.renderer.material = objectMaterial;
		created.transform.localScale = new Vector3 (xSize, ySize, 1);
		
	}
	
	void ResizeObject (GameObject go, Vector3 size, Vector3 location) {
		go.transform.localPosition = location;
		go.transform.localScale = size;
	}

	void FactoryCreate (GameObject go, float x, float y, float sizeX, float sizeY) {
		ResizeObject (go, 
			ResizeProportionally ( sizeX, sizeY ),
			PlaceProportionally (x, y, WholeScreen(), go.collider));
	}
	
	
	
	// Contains all the magic numbers for gameplay screen sizes
	void Update () {
		
		FactoryCreate (mainspringBin, 0, 0, .375f, .3f);
		
		FactoryCreate (rejectBin, .375f + SPACER, 0, .25f, .3f);
		
		// call spacer twice because value is already offset by spacer once
		FactoryCreate (balanceWheelBin, .625f + SPACER + SPACER, 0, .375f, .3f);
		
		// middle row: conveyor belt
		FactoryCreate (conveyorBelt, -1f, .3f + SPACER, 3f, .3f - SPACER);
		
		// bottom row
		FactoryCreate (gearBin, 0f, .6f + SPACER, .375f, .4f);
		
		FactoryCreate (table, .375f + SPACER, .6f + SPACER, .25f, .3f);
		
		FactoryCreate (indicatorBin, .625f + SPACER + SPACER, .6f + SPACER, .375f, .4f);
		
		// offscreen
		//FactoryCreate (watchSpawner, 0, .4f, .1f, .1f);
		
		
		
		
	}
}

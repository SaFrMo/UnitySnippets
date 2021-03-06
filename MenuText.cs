﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
[RequireComponent (typeof(TextMesh))]

public class MenuText : MonoBehaviour {
	
	/* USE.
	
	Create a class that inherits from MenuText. Declare 
	
	public override void Action() {
		[ action ]
	}
	
	in the child class. In the child class, have Action() do what you want the button to do. */
	
	/*
	// FIELDS
	*/
	
	// references to self. very handy.
	TextMesh t;
	BoxCollider c;
	
	// visible button selection
	public bool changeColorOnMouseOver = true;
	
	// basic colors
	public Color defaultColor = Color.white;
	public Color defaultMouseOverColor = Color.gray;
	
	// text
	public string defaultText = "";
	
	// fit collider to text.
	//		Wierd values because of Unity's wierd issues with 3Dtext size
	public float xMultiplier = 100f;
	public float yMultiplier = 35f;
	
	bool mouseOver;
	
	
	/*
	// METHODS
	*/
	
	// only called at Start(). shortcut to the textMesh
	// 		to which this script is attached
	void SelfReference() {
		t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
		c = (BoxCollider)gameObject.GetComponent(typeof(BoxCollider));
	}
	
	// very useful son of a gun
	void ChangeColor (Color c) {
		renderer.material.color = c;
	}
	
	// make the text WHATEVER YOU WANT
	void ChangeText (string txt) {
		t.text = txt;
		ResizeCollider ();
	}
	
	// fit Collider to text. Called as a subset of ChangeText,
	//		but adding its own method for flexibility's sake
	void ResizeCollider () {
		Vector3 cSize = new Vector3 (
			t.renderer.bounds.size.x * t.transform.localScale.x * xMultiplier, 
			t.renderer.bounds.size.y * t.transform.localScale.y * yMultiplier,
			1);
		c.size = cSize;
	}
	
	// Replace this with the action to take when clicked in the child class.
	public virtual void Action () {
		return;
	}
	
	void OnClick () {
		if (Input.GetMouseButtonDown(0)) {
			if (mouseOver) {
				// WHAT TO DO WHEN BUTTON IS CLICKED.
				Action ();
			}
		}
	}
	
	
	/*
	// MAKIN' IT HAPPEN
	*/
	
	void Start () {
		SelfReference();
		ChangeColor (defaultColor);
		ChangeText (defaultText);
	}
	
	void OnMouseEnter () {
		if (changeColorOnMouseOver)
			ChangeColor (defaultMouseOverColor);
		mouseOver = true;
	}
	
	void OnMouseExit () {
		ChangeColor (defaultColor);
		mouseOver = false;
	}
	
	void Update () {
		OnClick ();
	}
}

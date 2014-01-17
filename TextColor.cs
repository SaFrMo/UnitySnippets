using UnityEngine;
using System.Collections;

public class TextColor : MonoBehaviour {
	
	public Color c = Color.black;

	void Update () {
		renderer.material.color = c;
	}
}

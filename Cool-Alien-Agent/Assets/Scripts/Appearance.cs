using UnityEngine;
using System.Collections;

public class Appearance : MonoBehaviour {

	public Color color;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		camera.backgroundColor = color;
	}
}

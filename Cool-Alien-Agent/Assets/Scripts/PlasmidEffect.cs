﻿using UnityEngine;
using System.Collections;

public class PlasmidEffect : MonoBehaviour {

	public float speed = 0;
	public float green = 0;
	public float blue = 0;
	public float red = 0;
	public float size = 0;
	public float length = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateValues(float speed, float green, float blue, float red, float size, float length){
		this.speed = speed;
		this.green = green;
		this.blue = blue;
		this.red = red;
		this.size = size;
		this.length = length;
	}
}

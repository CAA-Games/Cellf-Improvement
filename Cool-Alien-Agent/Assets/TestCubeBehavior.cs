using UnityEngine;
using System.Collections;

public class TestCubeBehavior : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 v = new Vector2 (2,2); 
		this.gameObject.transform.Rotate(v);

	}
}
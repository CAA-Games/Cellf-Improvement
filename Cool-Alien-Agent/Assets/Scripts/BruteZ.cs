using UnityEngine;
using System.Collections;

public class BruteZ : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 p = transform.position;
		transform.position = new Vector3 (p.x, p.y, 0f);
	}
}

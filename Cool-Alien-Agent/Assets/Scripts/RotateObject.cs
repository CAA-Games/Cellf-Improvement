using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	public float speed = 1;
	float neg = 1;
	
	// Use this for initialization
	void Start () {
		neg = ApplicationLogic.minusOrPlus();
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Rotate (new Vector3(0,0,speed*neg));
	}
}
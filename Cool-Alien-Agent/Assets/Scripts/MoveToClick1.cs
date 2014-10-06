using UnityEngine;
using System.Collections;

public class MoveToClick1 : MonoBehaviour {

	private Vector3 targetPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			print ("updating position");
		}
		Vector2 distance = targetPos - transform.position;
		if (distance.magnitude > 1) {
			distance = distance.normalized;
		}

		transform.Translate(distance * 2.0f * Time.deltaTime);
	}
}

using UnityEngine;
using System.Collections;

public class MoveToClick : MonoBehaviour {
	
	public float moveSpeed = 2.0f;  // Units per secon
	private Vector3 targetPos;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}
		targetPos.z = transform.position.z;
		transform.LookAt (targetPos);
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}
}
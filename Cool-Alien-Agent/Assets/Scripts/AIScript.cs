using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {

	public float moveSpeed = 2.0f;  // Units per secon
	private Vector3 targetPos;
	private GameObject target;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null && targetPos != null) {
			if(Vector3.Distance(gameObject.transform.position, targetPos) < 0.1f){
				randomTarget();
			}
		} else {
			randomTarget();
		}

		targetPos.z = transform.position.z;
		transform.LookAt (targetPos);
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		target = col.gameObject;
	}

	void randomTarget(){
		targetPos = new Vector3 (gameObject.transform.position.x - 10, gameObject.transform.position.y - 10);
	}
}

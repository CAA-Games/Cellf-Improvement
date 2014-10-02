using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {

	public float moveSpeed = 2.0f;  // Units per secon
	private Vector3 targetPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (targetPos != null) {
			if(Vector3.Distance(gameObject.transform.position, targetPos) < 0.1f){
				randomTarget();
			}
		} else {
			randomTarget();
		}

		targetPos.z = transform.position.z;
		transform.LookAt (targetPos);
		transform.Translate(Vector3.forward * gameObject.GetComponent<PlasmidLogic>().currentSpeed * Time.deltaTime);
	}

	void OnTriggerStay2D(Collider2D col){
		print ("Triggered");
		targetPos = col.gameObject.transform.position;
	}

	void randomTarget(){
		print ("New random target");
		targetPos = new Vector3 (gameObject.transform.position.x + Random.Range(-5.0f, 5.0f), gameObject.transform.position.y - Random.Range(-5.0f, 5.0f));
	}
}

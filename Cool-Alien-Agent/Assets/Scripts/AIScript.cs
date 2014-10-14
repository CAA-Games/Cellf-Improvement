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

		Vector2 distance = targetPos - transform.position;
		if (distance.magnitude > 1) {
			distance = distance.normalized;
		}
		
		transform.Translate(distance * gameObject.GetComponent<PlasmidLogic>().currentSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Plasmid" || col.tag == "Player") {
			print ("Triggered");
			targetPos = col.gameObject.transform.position;
		}
	}

	void randomTarget(){
		print ("New random target");
		targetPos = new Vector3 (gameObject.transform.position.x + Random.Range(-5.0f, 5.0f), gameObject.transform.position.y - Random.Range(-5.0f, 5.0f));
	}
}

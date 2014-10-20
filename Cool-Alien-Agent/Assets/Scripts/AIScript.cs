﻿using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {

	public float moveSpeed = 2.0f;  // Units per secon
	private Vector3 targetPos;
	private bool plasmidShot = false;

	// Use this for initialization
	void Start () {
		targetPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.Range(1,1000) == 1){
			this.gameObject.SendMessage("dropPlasmid", randomShotTarget());
			plasmidShot = true;
			Invoke("plasmidOutOfSight",2);
		}

		if (targetPos != null) {
			if(Vector3.Distance(gameObject.transform.position, targetPos) < 0.1f){
				targetPos = randomTarget();
			}
		} else {
			targetPos = randomTarget();
		}

		Vector2 distance = targetPos - transform.position;
		if (distance.magnitude > 1) {
			distance = distance.normalized;
		}
		transform.Translate(distance * gameObject.GetComponent<PlasmidLogic>().currentSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Plasmid" && !plasmidShot) {
			targetPos = col.gameObject.transform.position;
		}
	}

	private Vector3 randomShotTarget(){
		return new Vector3 (transform.position.x + minusOrPlus() * Random.Range(2f,5.0f), transform.position.y + minusOrPlus() * Random.Range(2f,5.0f), 0);
	}

	private Vector3 randomTarget(){
		return new Vector3 (transform.position.x + Random.Range(-5.0f,5.0f), transform.position.y + Random.Range(-5.0f,5.0f), 0);
	}

	private float minusOrPlus(){
		if (Random.Range (0, 2) == 0) {
			return -1f;
		} else {
			return 1f;
		}
	}

	private void plasmidOutOfSight(){
		plasmidShot = false;
	}
}

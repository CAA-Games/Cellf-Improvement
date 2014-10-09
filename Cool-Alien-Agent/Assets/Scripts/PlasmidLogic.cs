using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlasmidLogic : MonoBehaviour
{
		public GameObject startingPlasmid;
		public int startingPlasmids;
		public List<PlasmidEffect> plasmidEffects;
		public GameObject PartPrefab;
		public float baseSpeed = 2.0f;
		public float baseGreen = 1f;
		public float baseBlue = 1f;
		public float baseRed = 1f;
		public float baseSize = 1f;
		public float baseLength = 1.5f;
		public float currentSpeed = 2.0f;
		public float currentGreen = 1f;
		public float currentBlue = 1f;
		public float currentRed = 1f;
		public float currentSize = 1f;
		public float currentLength = 1f;

		// Use this for initialization
		void Start ()
		{
				plasmidEffects = new List<PlasmidEffect> ();
				for (int i = 0; i < startingPlasmids; i++) {
						addPlasmid (new PlasmidEffect ());
				}
				updateBacterium ();
		}
	
		// Update is called once per frame
		void Update ()
		{		
		}

		public void addPlasmid (PlasmidEffect plasmid)
		{
				plasmidEffects.Add (plasmid);
				GameObject newPart = (GameObject)Instantiate (PartPrefab, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				newPart.GetComponent<PartLogic> ().player = this.gameObject;
				newPart.transform.parent = this.transform;
				updateBacterium ();
		}

		void updateBacterium ()
		{
				currentSpeed = baseSpeed;
				currentGreen = baseGreen;
				currentBlue = baseBlue;
				currentRed = baseRed;
				currentSize = baseSize;
				currentLength = baseLength;
				foreach (PlasmidEffect effect in plasmidEffects) {
						currentSpeed += effect.speed;
						currentGreen += effect.green;
						currentBlue += effect.blue;
						currentRed += effect.red;
						currentSize += effect.size;
						currentLength += effect.length;
				}
//			gameObject.renderer.material.color = new Color (currentRed, currentGreen, currentBlue);
				gameObject.transform.localScale = new Vector3 (currentSize, currentSize, currentLength * currentSize);
		}
}

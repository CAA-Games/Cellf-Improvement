using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlasmidLogic : MonoBehaviour
{
		private List<PlasmidEffect> plasmidEffects;
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
				plasmidEffects = new List<PlasmidEffect>();
		}
	
		// Update is called once per frame
		void Update ()
		{		
		}

		void OnCollisionEnter2D (Collision2D col)
		{
				if (col.gameObject.tag == "Plasmid") {
						plasmidEffects.Add (col.gameObject.GetComponent<PlasmidEffect>());
						updateBacterium();
						Destroy (col.gameObject);
				}
		}

		void updateBacterium(){
			currentSpeed = baseSpeed;
			currentGreen = baseGreen;
			currentBlue = baseBlue;
			currentRed = baseRed;
			currentSize = baseSize;
			currentLength = baseLength;
			foreach (PlasmidEffect effect in plasmidEffects){
				currentSpeed += effect.speed;
				currentGreen += effect.green;
				currentBlue += effect.blue;
				currentRed += effect.red;
				currentSize += effect.size;
				currentLength += effect.length;
			}
			gameObject.renderer.material.color = new Color (currentRed, currentGreen, currentBlue);
			gameObject.transform.localScale = new Vector3(currentSize, currentSize, currentLength * currentSize);
		}
}

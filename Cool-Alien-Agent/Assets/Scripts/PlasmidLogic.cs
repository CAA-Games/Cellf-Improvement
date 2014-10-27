using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class PlasmidLogic : MonoBehaviour
{
		public GameObject startingPlasmid;
		public int startingPlasmids;
		public List<GameObject> partPrefabs;
		public GameObject instantiatingPlasmid;
		public Dictionary<GameObject, PlasmidEffect> cells;
		private int plasmidsToAdd;
		public float baseSpeed = 2.0f;
		public float baseGreen = 1f;
		public float baseBlue = 1f;
		public float baseRed = 1f;
		public float baseSize = 0f;
		public float baseLength = 1.5f;
		public float currentSpeed = 2.0f;
		public float currentGreen = 1f;
		public float currentBlue = 1f;
		public float currentRed = 1f;
		public float currentSize = 0f;
		public float currentLength = 1f;
	
		void Start ()
		{
				cells = new Dictionary<GameObject,PlasmidEffect> ();
				plasmidsToAdd = 0;
				for (int i = 0; i < startingPlasmids; i++) {
						plasmidsToAdd++;
				}
				updateBacterium ();
		}

		void Update ()
		{		
				if (plasmidsToAdd > 0) {
						addPlasmid (startingPlasmid.GetComponent<PlasmidEffect> ());
						plasmidsToAdd--;
				}
		}

		public void addPlasmid (PlasmidEffect plasmid)
		{
				cells.Add (newChildPart (plasmid), plasmid);
				updateBacterium ();
		}

		private GameObject newChildPart (PlasmidEffect plasmid)
		{
				GameObject newPart = (GameObject)Instantiate (plasmid.appearance, randomMiddleLocation (), Quaternion.identity);
				newPart.GetComponent<CellLogic> ().player = gameObject;
				newPart.transform.parent = transform;
				newPart.tag = gameObject.tag;
				
				return newPart;
		}

		private Vector3 randomMiddleLocation ()
		{
				return new Vector3 (this.transform.position.x + UnityEngine.Random.Range (-0.5f, 0.5f), this.transform.position.y + UnityEngine.Random.Range (-0.5f, 0.5f), 0);
		}

		void updateBacterium ()
		{
				if (cells.Count < 0) {
						print ("A bacterium died!");
						Destroy (gameObject);
				} else {
						currentSpeed = baseSpeed;
						currentGreen = baseGreen;
						currentBlue = baseBlue;
						currentRed = baseRed;
						currentSize = baseSize;
						currentLength = baseLength;
						foreach (PlasmidEffect effect in cells.Values) {
								currentSpeed += effect.speed;
								currentGreen += effect.green;
								currentBlue += effect.blue;
								currentRed += effect.red;
								currentSize += effect.size;
								currentLength += effect.length;
						}
						foreach (GameObject part in cells.Keys) {
								part.transform.localScale = new Vector3 (1 + currentSize / 20, 1 + currentSize / 20, part.transform.localScale.z);
								//part.GetComponent<CellAppearance>().updateColor(82 - (int)currentRed * 3, 99 - (int)currentGreen * 3, 126 - (int)currentBlue * 3);
						}
				}
		}

		public void dropPlasmid (GameObject plasmidToDrop)
		{
				GameObject newPlasmid = (GameObject)Instantiate (instantiatingPlasmid, new Vector3 (plasmidToDrop.transform.position.x, plasmidToDrop.transform.position.y, 0), Quaternion.identity);
				PlasmidEffect effect = newPlasmid.gameObject.AddComponent<PlasmidEffect> ();
				copyPlasmidEffect (effect, cells [plasmidToDrop]);
				Vector3 direction = plasmidToDrop.transform.position;
				if (direction.magnitude > 1) {
						direction = direction.normalized;
				}
				newPlasmid.rigidbody2D.AddForce (direction * 500);
				RemoveCell (plasmidToDrop);
		}

		void dropPlasmid (Vector3 direction)
		{
				if (cells.Count <= 1) {
						return;
				}
				GameObject cellToBeShot = Enumerable.ToList (cells.Keys) [0];
				float minDistance = Vector3.Distance (cellToBeShot.transform.position, direction);
				float tempDistance;
				foreach (GameObject cell in cells.Keys) {
						tempDistance = Vector3.Distance (cell.transform.position, direction);
						if (tempDistance < minDistance) {
								minDistance = tempDistance;
								cellToBeShot = cell;
						}
				}

				GameObject newPlasmid = (GameObject)Instantiate (instantiatingPlasmid, new Vector3 (cellToBeShot.transform.position.x, cellToBeShot.transform.position.y, 0), Quaternion.identity);
				PlasmidEffect effect = newPlasmid.gameObject.AddComponent<PlasmidEffect> ();
				copyPlasmidEffect (effect, cells [cellToBeShot]);
				direction = direction - transform.position;
				if (direction.magnitude > 1) {
						direction = direction.normalized;
				}

				newPlasmid.rigidbody2D.AddForce (direction * 500);
				RemoveCell (cellToBeShot);
		}

		public void RemoveCell (GameObject cell)
		{
		
				cells.Remove (cell);
				Destroy (cell);
				updateBacterium ();
		}

		void copyPlasmidEffect (PlasmidEffect copyTo, PlasmidEffect copyFrom)
		{
				copyTo.updateValues (copyFrom.speed, copyFrom.green, copyFrom.blue, copyFrom.red, copyFrom.size, copyFrom.length, copyFrom.appearance);
		}
}

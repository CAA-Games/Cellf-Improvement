using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
				cells = new Dictionary<GameObject,PlasmidEffect> ();
				plasmidsToAdd = 0;
				for (int i = 0; i < startingPlasmids; i++) {
					plasmidsToAdd++;
				}
				updateBacterium ();
		}
	
		// Update is called once per frame
		void Update ()
		{		
			if (plasmidsToAdd > 0) {
				newChildPart();
				plasmidsToAdd--;
			}
		}

		public void addPlasmid (PlasmidEffect plasmid)
		{
				cells.Add (newChildPart(), plasmid);
				updateBacterium ();
		}

		private GameObject newChildPart(){
			print (Random.Range (0, partPrefabs.Count - 1));
			GameObject newPart = (GameObject)Instantiate (partPrefabs[Random.Range(0,partPrefabs.Count)], randomMiddleLocation(), Quaternion.identity);
			newPart.GetComponent<PartLogic> ().player = this.gameObject;
			newPart.transform.parent = this.transform;
			return newPart;
		}

		private Vector3 randomMiddleLocation(){
			return new Vector3 (this.transform.position.x + Random.Range(-0.5f,0.5f), this.transform.position.y + Random.Range(-0.5f,0.5f), this.transform.position.z + Random.Range(-0.5f,0.5f));
		}

		void updateBacterium ()
		{
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
//			gameObject.renderer.material.color = new Color (currentRed, currentGreen, currentBlue);
				gameObject.transform.localScale = new Vector3 (currentSize, currentSize, currentLength * currentSize);
		}

		void dropAPlasmid () {
			if (cells.Count == 1) {
				return;
			}
			print("dropping Plasmid");
			GameObject cellToBeShot = (Enumerable.ToList(cells.Keys)[Random.Range(0,cells.Keys.Count)]);
			GameObject newPlasmid = (GameObject)Instantiate (instantiatingPlasmid, new Vector3(cellToBeShot.transform.position.x + 1,cellToBeShot.transform.position.y + 1,cellToBeShot.transform.position.z + 1), Quaternion.identity);
			PlasmidEffect effect = newPlasmid.gameObject.AddComponent<PlasmidEffect>();
			copyPlasmidEffect(effect,cells[cellToBeShot]);
			
			var targetPos = GetWorldPositionOnPlane(Input.mousePosition, 0.0f);
			
			Vector2 distance = targetPos - transform.position;
			if (distance.magnitude > 1) {
				distance = distance.normalized;
			}

			newPlasmid.rigidbody2D.AddForce (distance * 500);

			cells.Remove (cellToBeShot);
			Destroy (cellToBeShot);
			updateBacterium ();
		}

		void copyPlasmidEffect(PlasmidEffect copyTo, PlasmidEffect copyFrom){
			copyTo.updateValues (copyFrom.speed, copyFrom.green, copyFrom.blue, copyFrom.red, copyFrom.size, copyFrom.length);
		}

	private Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray, out distance);
		return ray.GetPoint(distance);
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIDirector : MonoBehaviour
{

		public List<GameObject> partPrefabs;
		public GameObject plasmidPrefab;
		public GameObject virusPrefab;
		public GameObject player;
		private static int xp;
		public int stage;
		private int spawnInterval = 0;
		private float timer = 1;

		void Update ()
		{ 
				timer -= Time.deltaTime;
				if (stage == 0) {
						if (timer < 0) {
								spawnPlasmid ();
								timer = Random.Range (1f, 2f);
						}
				}
		}

		public static void xpUp (int amount)
		{
				xp += amount;
		}

		public static void xpUp ()
		{
				xpUp (1); 
		}

		void CheckXp ()
		{
				if (xp > 1) {
						stage++;	
				}
		}

		private void spawnPlasmid ()
		{
				GameObject newPlasmid = (GameObject)Instantiate (plasmidPrefab, randomLocation (), Quaternion.identity);
				PlasmidEffect effect = newPlasmid.gameObject.AddComponent<PlasmidEffect> ();
				randomizeAttributes (effect);
		}

		private void spawnVirus ()
		{
				GameObject newVirus = (GameObject)Instantiate (virusPrefab, randomLocation (), Quaternion.identity);
		}

		private Vector3 randomLocation ()
		{
				Vector3 playerPosition = player.transform.position;
				Vector3 randomizedPosition = ApplicationLogic.GetWorldPositionOnPlane (Vector3.zero, 0.0f);
				randomizedPosition -= playerPosition;
				Quaternion rotation = ApplicationLogic.randomRotation();
				randomizedPosition = rotation * randomizedPosition;
				randomizedPosition += playerPosition;
				return randomizedPosition;
		}

		private void randomizeAttributes (PlasmidEffect effect)
		{
				effect.updateValues (Random.Range (-1f, 2f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), partPrefabs [UnityEngine.Random.Range (0, partPrefabs.Count)]);
		}
}

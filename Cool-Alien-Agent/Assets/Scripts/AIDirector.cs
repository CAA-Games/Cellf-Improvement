using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIDirector : MonoBehaviour
{

		public List<GameObject> partPrefabs;
		public GameObject plasmidPrefab;
		public GameObject virusPrefab;
		public GameObject player;
		public GameObject enemy;
		private int playerSize;
		private static int xp;
		public int stage;
		private int spawnInterval = 0;
		private float timer = 1;
		public float stage1spawnInterval = 4;
		public float stage1spawnVariance = 2;
		public float stage2spawnInterval = 4;
		public float stage2spawnVariance = 2;
		public float spawnRange = 10, spawnRangeVariance = 5;
		public float plasmidLifetime;

		void Update ()
		{ 
				timer -= Time.deltaTime;
				switch (stage) {
				case 0:
						if (timer < 0) {
								spawnPlasmid ();
								timer = Random.Range (stage1spawnInterval, stage1spawnInterval + stage1spawnVariance);
						}
						break;
				case 1:
						if (timer < 0) {
								spawnEnemy (playerSize - 1);
								timer = Random.Range (3f, 4f);
						}
						break;
				}
				
				playerSize = player.GetComponent<PlasmidLogic> ().cells.Count;
				CheckXp ();
		}

		public static void xpUp (string tag, int amount)
		{
				if (tag.StartsWith ("Player")) {
						xp += amount;
				}
		}

		public static void xpUp (string tag)
		{
				xpUp (tag, 1); 
		}

		void CheckXp ()
		{
				if (xp > 3 && stage == 0) {
						stage++;	
				}
		}

		private void spawnPlasmid ()
		{
				GameObject newPlasmid = (GameObject)Instantiate (plasmidPrefab, randomLocation (), Quaternion.identity);
				PlasmidEffect effect = newPlasmid.gameObject.AddComponent<PlasmidEffect> ();
				randomizeAttributes (effect);
		}

		private void spawnEnemy (int size)
		{
				size++;
				//			GameObject newEnemy = (GameObject)Instantiate (enemy, randomLocation (), Quaternion.identity);
				
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
				randomizedPosition = ApplicationLogic.randomRotation () * randomizedPosition;
				randomizedPosition *= Random.Range (spawnRange, spawnRange + spawnRangeVariance);
				randomizedPosition += playerPosition;
				return randomizedPosition;
		}

		private void randomizeAttributes (PlasmidEffect effect)
		{
				effect.updateValues (Random.Range (-1f, 2f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), partPrefabs [UnityEngine.Random.Range (0, partPrefabs.Count)]);
		}
}

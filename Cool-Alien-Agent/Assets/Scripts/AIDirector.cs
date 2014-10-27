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
		public static int xp;
		public int stage;
		public float plasmidTimer = 1;
		public float enemyTimer = 1;
		public float spawnRange = 10, spawnRangeVariance = 5;
		public bool virusActive = false;
		public bool nobodyHasBeenInfected = true;

		void Update ()
		{ 
				plasmidTimer -= Time.deltaTime;
				enemyTimer -= Time.deltaTime;
				if (stage == 0) {
						if (plasmidTimer < 0) {
								spawnPlasmid (0.5);
								plasmidTimer = Random.Range (4, 8);
						}
				} else if (stage == 1) {
						if (plasmidTimer < 0) {
								spawnPlasmid (1);
								plasmidTimer = Random.Range (8, 10);
						}
						if (enemyTimer < 0) {
								spawnEnemy (Mathf.Max (Random.Range (0, playerSize - 1), 0));
								plasmidTimer = Random.Range (4f, 9f);
						}
				} else if (stage == 2) {
						if (!virusActive && nobodyHasBeenInfected) {
								spawnVirus ();
								virusActive = true;
						}
				
				}
				if (Time.frameCount % 60 == 0) {
						playerSize = player.GetComponent<PlasmidLogic> ().cells.Count;
						CheckXp ();
				}
		}

		public static void xpUp (string tag, int amount)
		{
				if (tag.StartsWith ("Player")) {
						xp += amount;
				}
		}

		public static void xpUp (string tag)
		{
				xpUp (tag, 10); 
		}

		void CheckXp ()
		{
				if (xp > 30 && stage == 0) {
						stage++;	
				} else if (xp > 110 && stage == 1) {
						stage++;
				}
		}
	
		private void spawnPlasmid (float stage0spawnRangeModifier)
		{
				spawnPlasmid (randomLocation (stage0spawnRangeModifier));
		}

		private void spawnPlasmid ()
		{
				spawnPlasmid (randomLocation (1));
		}

		private void spawnPlasmid (Vector3 position)
		{
				GameObject newPlasmid = (GameObject)Instantiate (plasmidPrefab, position, Quaternion.identity);
				PlasmidEffect effect = newPlasmid.gameObject.AddComponent<PlasmidEffect> ();
				randomizeAttributes (effect);
		}

		private void spawnEnemy (int size)
		{
				GameObject newEnemy = (GameObject)Instantiate (enemy, randomLocation (1), Quaternion.identity);
				for (int i = 0; i < size; i++) {
						spawnPlasmid (newEnemy.transform.position);
				}
		}

		private void spawnVirus ()
		{
				GameObject newVirus = (GameObject)Instantiate (virusPrefab, randomLocation (1), Quaternion.identity);
		}

		private Vector3 randomLocation (float rangeModifier)
		{
				Vector3 playerPosition = player.transform.position;
				Vector3 randomizedPosition = ApplicationLogic.GetWorldPositionOnPlane (Vector3.zero, 0.0f);
				randomizedPosition -= playerPosition;
				randomizedPosition = ApplicationLogic.randomRotation () * randomizedPosition;
				randomizedPosition *= Random.Range (spawnRange, spawnRange + spawnRangeVariance) * rangeModifier;
				randomizedPosition += playerPosition;
				randomizedPosition = new Vector3 (randomizedPosition.x, randomizedPosition.y, 0);
				return randomizedPosition;
		}

		private void randomizeAttributes (PlasmidEffect effect)
		{
				effect.updateValues (Random.Range (-1f, 2f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), partPrefabs [UnityEngine.Random.Range (0, partPrefabs.Count)]);
		}
}

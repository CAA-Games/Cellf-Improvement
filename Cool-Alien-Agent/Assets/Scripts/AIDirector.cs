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
		public static int stage = 3;
		public float plasmidTimer = 1;
		public float enemyTimer = 1;
		public float spawnRange = 10, spawnRangeVariance = 5;
		public static bool virusActive = false;
		public static bool noInfectionsYet = true;

		void Update ()
		{ 
				plasmidTimer -= Time.deltaTime;
				enemyTimer -= Time.deltaTime;
				if (stage == 0) {
						if (plasmidTimer < 0) {
								spawnPlasmid (0.6f);
								plasmidTimer = Random.Range (4f, 8f);
						}
				} else if (stage == 1) {
						if (plasmidTimer < 0) {
								spawnPlasmid (1);
								plasmidTimer = Random.Range (5f, 9f);
						}
						if (enemyTimer < 0) {
								spawnEnemy (Mathf.Max (Random.Range (0, playerSize - 1), 0));
								enemyTimer = Random.Range (2f, 6f);
						}
				} else if (stage == 2) {
						if (!virusActive && noInfectionsYet) {
								spawnVirus ();
						}
						if (plasmidTimer < 0) {
								spawnPlasmid (1);
								plasmidTimer = Random.Range (8f, 10f);
						}
						if (enemyTimer < 0) {
								spawnEnemy (Random.Range (1, playerSize + 3));
								enemyTimer = Random.Range (1f, 5f);
						}
				} else if (stage == 3) {
						noInfectionsYet = false;
						virusActive = false;
						stage++;		
						GameObject boss = spawnEnemy (2);
						boss.AddComponent<BossLogic> ();
				} else if (stage == 5) {
						if (!virusActive && noInfectionsYet) {
								spawnVirus ();
						}
						if (plasmidTimer < 0) {
								spawnPlasmid (1);
								plasmidTimer = Random.Range (8f, 10f);
						}
						if (enemyTimer < 0) {
								spawnEnemy (Random.Range (1, playerSize + 5));
								enemyTimer = Random.Range (1f, 5f);
						}
				}
				if (Time.renderedFrameCount % 60 == 0 && player) {
						playerSize = player.GetComponent<BacteriumLogic> ().cells.Count;
						CheckXp ();
				}
		}

		public static void xpUp (string tag, int amount)
		{
				xp += amount;
				
		}

		public static void xpUp (string tag)
		{
				if (tag.StartsWith ("Player")) {
						xpUp (tag, 10); 
				}
				if (tag.StartsWith ("Boss")) {
						stage = 5;
				}
		}

		public static void infectionHappened ()
		{
				noInfectionsYet = false;
		}

		public static void virusDecayed ()
		{
				virusActive = false;
		}

		public static void PlayerDied ()
		{

		}

		void CheckXp ()
		{
				if (xp > 30 && stage == 0) {
						stage++;	
				} else if (xp > 200 && stage == 1) {
						stage++;
				} else if (xp > 400 && stage == 2) {
						stage++;
				}
		}
	
		private void spawnPlasmid (float range)
		{
				spawnPlasmid (randomLocation (range));
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

		private GameObject spawnEnemy (int size)
		{
				GameObject newEnemy = (GameObject)Instantiate (enemy, randomLocation (1), Quaternion.identity);
				for (int i = 0; i < size; i++) {
						spawnPlasmid (newEnemy.transform.position);
				}
				return newEnemy;
		}

		private void spawnVirus ()
		{
				Instantiate (virusPrefab, randomLocation (1), Quaternion.identity);
				virusActive = true;
		}

		private Vector3 randomLocation (float rangeModifier)
		{
				Vector3 playerPosition;
				if (player) {
						playerPosition = player.transform.position;
				} else {
						playerPosition = new Vector3 (transform.position.x, transform.position.y, 0);
				}
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
				//			effect.updateValues (Random.Range (-1f, 2f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), partPrefabs [UnityEngine.Random.Range (0, partPrefabs.Count)]);
				effect.updateValues (Random.Range (-0.1f, 0.1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), partPrefabs [UnityEngine.Random.Range (0, partPrefabs.Count)]);
		}
}

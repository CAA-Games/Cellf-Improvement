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
		private float timer = 1;
		public float stage0spawnRangeModifier = 0.5f;
		public float stage0spawnInterval = 4;
		public float stage0spawnVariance = 2;
		public float stage1spawnInterval = 4;
		public float stage1spawnVariance = 2;
		public float spawnRange = 10, spawnRangeVariance = 5;

		void Update ()
		{ 
				timer -= Time.deltaTime;
				switch (stage) {
				case 0:
						if (timer < 0) {
								spawnPlasmid (stage0spawnRangeModifier);
								timer = Random.Range (stage0spawnInterval, stage0spawnInterval + stage0spawnVariance);
						}
						break;
				case 1:
						if (timer < 0) {
								spawnEnemy (playerSize - 1);
								timer = Random.Range (3f, 4f);
						}
						break;
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
				print ("Experience: " + xp);
				if (xp > 30 && stage == 0) {
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

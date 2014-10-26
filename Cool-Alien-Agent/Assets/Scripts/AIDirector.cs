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

		void Update ()
		{
				if (Random.Range (1, 100) == 1) {
						spawnPlasmid ();
				}
				if (Random.Range (1, 10000) == 1) {
						print ("Virus spawned!");
						spawnVirus ();
				}
		}

		public static void xpUp (int amount)
		{
				xp += amount;
		}

		public static void xpUp ()
		{
				xp += 1;
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
				return new Vector3 (Random.Range (-25f, 25f), Random.Range (-25f, 25f), 0);
		}

		private void randomizeAttributes (PlasmidEffect effect)
		{
				effect.updateValues (Random.Range (-1f, 2f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), Random.Range (-1f, 1f), partPrefabs [UnityEngine.Random.Range (0, partPrefabs.Count)]);
		}
}

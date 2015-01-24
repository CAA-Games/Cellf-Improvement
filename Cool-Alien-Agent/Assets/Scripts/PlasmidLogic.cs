using UnityEngine;
using System.Collections;

public class PlasmidLogic : MonoBehaviour
{

		public float gracePeriod = 3f;
		public float currentGraceTime = 0f;
		public bool canBePickedUp = false;
		public GameObject spawnEffect;
		public bool spawnWithEffect = true;

		void Start ()
		{
				if (spawnWithEffect) {
						Destroy (Instantiate (spawnEffect, transform.position, Quaternion.identity), 11.0f);
				}
		}

		void Update ()
		{
				if (!canBePickedUp) {
						currentGraceTime += Time.deltaTime;
				}
				if (currentGraceTime >= gracePeriod) {
						canBePickedUp = true;
				}
		}
}

using UnityEngine;
using System.Collections;

public class PlasmidLogic : MonoBehaviour
{

		public float gracePeriod = 3f;
		public float currentGraceTime = 0f;
		public bool canBePickedUp = false;

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

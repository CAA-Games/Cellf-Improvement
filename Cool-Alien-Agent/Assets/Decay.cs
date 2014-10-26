using UnityEngine;
using System.Collections;

public class Decay : MonoBehaviour
{

		public float lifetime;
		public float remainingLifetime;
		public bool visibleOnCamera;

		void Update ()
		{
				if (!visibleOnCamera) {
						remainingLifetime += Time.deltaTime;
						if (remainingLifetime >= lifetime) {
								Destroy (gameObject);
						}
				}
		}

		void OnBecameVisible ()
		{
				visibleOnCamera = true;
				remainingLifetime = 0;
		}

		void OnBecameInvisible ()
		{
				visibleOnCamera = false;
		}
}

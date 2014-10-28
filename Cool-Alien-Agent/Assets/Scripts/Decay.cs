using UnityEngine;
using System.Collections;

public class Decay : MonoBehaviour
{

		public float lifetime;
		public float currentAliveTime;
		public bool visibleOnCamera;

		void Update ()
		{
				if (!visibleOnCamera) {
						currentAliveTime += Time.deltaTime;
						if (currentAliveTime >= lifetime) {
								Destroy (gameObject);
						}
				}
		}

		void OnBecameVisible ()
		{
				visibleOnCamera = true;
				currentAliveTime = 0;
		}

		void OnBecameInvisible ()
		{
				visibleOnCamera = false;
		}
}

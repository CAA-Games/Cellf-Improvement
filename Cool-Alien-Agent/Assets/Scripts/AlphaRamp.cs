using UnityEngine;
using System.Collections;

public class AlphaRamp : MonoBehaviour
{

		public GameObject startOverText;
		public float increment;
		public float startingAlpha = -2;
		private float currentAlpha;
		public bool activeAtStart = false;
		public bool rampOut = false;

		void Start ()
		{
				currentAlpha = startingAlpha;
				gameObject.SetActive (activeAtStart);
		}

		void Update ()
		{
				if (currentAlpha <= 1) {
						currentAlpha += increment * Time.deltaTime;
						renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, currentAlpha);
						if (rampOut && currentAlpha >= 0.90f) {
								increment = -0.2f;
						}
				} else if (startOverText && AIDirector.stage < 5) {
						startOverText.SetActive (true);
				}
				if (gameObject.GetComponent<StartOver> ()) {
						gameObject.GetComponent<StartOver> ().enabled = true;
				}
				if (currentAlpha < -10) {
						gameObject.SetActive (false);
				}
		}
}

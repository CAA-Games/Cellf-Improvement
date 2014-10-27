using UnityEngine;
using System.Collections;

public class AlphaRamp : MonoBehaviour
{

		public GameObject startOverText;
		public float increment;
		public float startingAlpha = -2;
		private float currentAlpha;

		void Start ()
		{
				currentAlpha = startingAlpha;
				gameObject.SetActive (false);
		}

		void Update ()
		{
				if (currentAlpha <= 1) {
						currentAlpha += increment * Time.deltaTime;
						renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, currentAlpha);
				} else if (startOverText) {
						startOverText.SetActive (true);
				}
		}
}

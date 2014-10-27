using UnityEngine;
using System.Collections;

public class AlphaRamp : MonoBehaviour
{

		public float increment;
		private float currentAlpha = -2;

		void Start ()
		{
				gameObject.SetActive (false);
		}

		void Update ()
		{
				if (currentAlpha <= 1) {
						currentAlpha += increment * Time.deltaTime;
						renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, currentAlpha);
				}
		}
}

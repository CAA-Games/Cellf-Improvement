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
				currentAlpha += increment * Time.deltaTime;
				renderer.material.color = new Color (renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, currentAlpha);
		}
}

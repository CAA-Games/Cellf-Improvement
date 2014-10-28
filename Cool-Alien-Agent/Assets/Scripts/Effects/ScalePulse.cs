using UnityEngine;
using System.Collections;

public class ScalePulse : MonoBehaviour
{
		public float baseScale = 1;
		public float pulseSizeDifference = 0.2f;
		public float rate = 0.02f;
		private float randomSeed;

		void Start ()
		{
				randomSeed = Random.Range (0, 60);
		}

		void Update ()
		{
				Vector3 scale = new Vector3 (baseScale, baseScale, baseScale) + Vector3.one * Mathf.Sin (randomSeed + Time.renderedFrameCount * rate) * pulseSizeDifference;
				transform.localScale = scale;
		}
}

using UnityEngine;
using System.Collections;

public class CellAppearance : MonoBehaviour
{
		public float randomVariance;
		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void updateColor(int r, int g, int b){
			renderer.material.color = new Color ((float)r/255 + Random.Range (-randomVariance, randomVariance),
		                                     (float)b/255 + Random.Range (-randomVariance, randomVariance),
		                                     (float)g/255 + Random.Range (-randomVariance, randomVariance));
		}
}

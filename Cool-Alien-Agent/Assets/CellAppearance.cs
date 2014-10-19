using UnityEngine;
using System.Collections;

public class CellAppearance : MonoBehaviour
{
		public float randomVariance;
		// Use this for initialization
		void Start ()
		{
				
				Color c = renderer.material.color;
				renderer.material.color = new Color (c.r + Random.Range (-randomVariance, randomVariance),
		                                     c.b + Random.Range (-randomVariance, randomVariance),
		                                     c.g + Random.Range (-randomVariance, randomVariance));
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}

using UnityEngine;
using System.Collections;
using System;

public class SmoothFollow : MonoBehaviour
{

		public GameObject objectToFollow;
		public float z;
		public float smoothness;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
			setZ ();
				if (objectToFollow) {
						Vector3 newPosition = new Vector3 (objectToFollow.transform.position.x, objectToFollow.transform.position.y, z);
						gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, newPosition, smoothness);						
				}			
		}

		public void setZ(){
			z = Math.Min(((float) Math.Log((objectToFollow.GetComponent<PlasmidLogic>().cells.Count))/2) * -20f,-20);
		}
}

using UnityEngine;
using System.Collections;

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
				if (objectToFollow) {
						gameObject.transform.position = Vector2.Lerp (gameObject.transform.position, objectToFollow.transform.position, smoothness);						
						gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, z);
				}
		}
}

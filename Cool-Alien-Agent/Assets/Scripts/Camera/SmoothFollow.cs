using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{

		public GameObject objectToFollow;
		public float z;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (objectToFollow) {
						gameObject.transform.position = Vector2.Lerp (gameObject.transform.position, objectToFollow.transform.position, 0.05f);						
						gameObject.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, z);
				}
		}
}

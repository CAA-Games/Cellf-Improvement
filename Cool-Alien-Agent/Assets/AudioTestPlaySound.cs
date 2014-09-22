using UnityEngine;
using System.Collections;

public class AudioTestPlaySound : MonoBehaviour
{

		public AudioSource a;
		public AudioSource b;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{	
				
				float mouseX = Input.mousePosition.x / 5.0f;
				float mouseY = Input.mousePosition.y / 100.0f;
				if (Input.GetMouseButtonDown (0)) {
						a.time = mouseX;
						b.time = mouseX;
				}
				a.volume = mouseY;
				b.volume = 1 - mouseY;
				
		}
}

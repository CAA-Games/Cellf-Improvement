using UnityEngine;
using System.Collections;

public class StartOver : MonoBehaviour
{
		void Update ()
		{
				if (Input.GetMouseButtonDown (0)) {
						AIDirector.startOver ();
						Application.LoadLevel (0);		
				}
		}
}

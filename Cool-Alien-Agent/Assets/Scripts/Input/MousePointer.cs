using UnityEngine;
using System.Collections;

public class MousePointer : MonoBehaviour
{

		public bool showOSCursor;

		void Start ()
		{
				Screen.showCursor = showOSCursor;
		}

		void Update ()
		{
				transform.position = ApplicationLogic.GetWorldPositionOnPlane (Input.mousePosition, 0);
		}
}

using UnityEngine;
using System.Collections;

public class ApplicationLogic : MonoBehaviour
{

		public static bool isShuttingDown;

		// Use this for initialization
		void Start ()
		{
				isShuttingDown = false;
		}

		void OnApplicationQuit ()
		{
				isShuttingDown = true;
		}
}

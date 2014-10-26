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

		public static Quaternion randomRotation ()
		{
				return Quaternion.AngleAxis (Random.Range (0f, 360f), Vector3.forward);
		}

		/**
		 *  Uses raycasting to find given screen position on a plane perpendicular to the camera
		 *  in given z coordinate;
		 * 
		 *  http://answers.unity3d.com/questions/566519/camerascreentoworldpoint-in-perspective.html
		 */
		public static Vector3 GetWorldPositionOnPlane (Vector3 screenPosition, float z)
		{
				Ray ray = Camera.main.ScreenPointToRay (screenPosition);
				Plane xy = new Plane (Vector3.forward, new Vector3 (0, 0, z));
				float distance;
				xy.Raycast (ray, out distance);
				return ray.GetPoint (distance);
		}

		public static Vector3 randomTarget (Transform entity)
		{
				return new Vector3 (entity.position.x + Random.Range (-5.0f, 5.0f), entity.position.y + Random.Range (-5.0f, 5.0f), 0);
		}
	
		public static float minusOrPlus ()
		{
				if (Random.Range (0, 2) == 0) {
						return -1f;
				} else {
						return 1f;
				}
		}
}

using UnityEngine;
using System.Collections;

public class MoveToClickPersp : MonoBehaviour {
	
	private Vector3 targetPos;
	
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	
	void Update () {
		if (Input.GetMouseButton(0)) {
			targetPos = GetWorldPositionOnPlane(Input.mousePosition, 0.0f);
		}
		Vector2 distance = targetPos - transform.position;
		if (distance.magnitude > 1) {
			distance = distance.normalized;
		}
		
		transform.Translate(distance * gameObject.GetComponent<PlasmidLogic>().currentSpeed * Time.deltaTime);
	}

	/**
	 *  Uses raycasting to find mouse position on a plane perpendicular to the camera
	 *  in given z coordinate;
	 * 
	 *  http://answers.unity3d.com/questions/566519/camerascreentoworldpoint-in-perspective.html
	 */
	private Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray, out distance);
		return ray.GetPoint(distance);
	}

}

using UnityEngine;
using System.Collections;

public class MoveToClickPersp : MonoBehaviour
{
	
		public Vector3 targetPos;
	
		// Use this for initialization
		void Start ()
		{
				targetPos = transform.position;
		}
		// Update is called once per frame
	
		void Update ()
		{
				if (Input.GetMouseButton (0)) {
						targetPos = ApplicationLogic.GetWorldPositionOnPlane (Input.mousePosition, 0.0f);
				}		
				if (Input.GetMouseButtonDown (1)) {
						this.gameObject.SendMessage ("dropPlasmid", ApplicationLogic.GetWorldPositionOnPlane (Input.mousePosition, 0.0f));
				}
				Vector2 distance = targetPos - transform.position;
				if (distance.magnitude > 1) {
						distance = distance.normalized;
				}
		
				transform.Translate (distance * gameObject.GetComponent<BacteriumLogic> ().currentSpeed * Time.deltaTime);
		}
}

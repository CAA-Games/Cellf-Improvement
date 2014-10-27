using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

		public Vector3 targetPos;

		void Start ()
		{
				targetPos = transform.position;
		}

		void Update ()
		{
				if (Random.Range (1, 1000) == 1) {
						this.gameObject.SendMessage ("dropPlasmid", randomShotTarget ());
				}

				if (Vector3.Distance (gameObject.transform.position, targetPos) < 0.1f) {
						targetPos = ApplicationLogic.randomTarget (transform);
				}

				Vector2 distance = targetPos - transform.position;
				if (distance.magnitude > 1) {
						distance = distance.normalized;
				}
				transform.Translate (distance * gameObject.GetComponent<BacteriumLogic> ().currentSpeed * Time.deltaTime);
		}

		void OnTriggerStay2D (Collider2D col)
		{
				if (col.tag == "Plasmid") {
						targetPos = col.gameObject.transform.position;
				}
				if (col.tag == "Player") {
						if (col.transform.parent.gameObject.GetComponent<BacteriumLogic> ().cells.Count < gameObject.GetComponent<BacteriumLogic> ().cells.Count) {
								targetPos = col.gameObject.transform.position;
						}
				}
		}

		private Vector3 randomShotTarget ()
		{
				return new Vector3 (transform.position.x + ApplicationLogic.minusOrPlus () * Random.Range (2f, 5.0f), transform.position.y + ApplicationLogic.minusOrPlus () * Random.Range (2f, 5.0f), 0);
		}
}

using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

		public Vector3 targetPos;
		private bool plasmidShot = false;

		// Use this for initialization
		void Start ()
		{
				targetPos = transform.position;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Random.Range (1, 1000) == 1) {
						this.gameObject.SendMessage ("dropPlasmid", randomShotTarget ());
						plasmidShot = true;
						Invoke ("plasmidOutOfSight", 2);
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

		void OnTriggerEnter2D (Collider2D col)
		{
				if (col.tag == "Plasmid" && !plasmidShot) {
						targetPos = col.gameObject.transform.position;
				}
		}

		private Vector3 randomShotTarget ()
		{
				return new Vector3 (transform.position.x + ApplicationLogic.minusOrPlus () * Random.Range (2f, 5.0f), transform.position.y + ApplicationLogic.minusOrPlus () * Random.Range (2f, 5.0f), 0);
		}

		private void plasmidOutOfSight ()
		{
				plasmidShot = false;
		}
}

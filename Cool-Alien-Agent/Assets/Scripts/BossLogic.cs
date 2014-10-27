using UnityEngine;
using System.Collections;

public class BossLogic : MonoBehaviour
{

		public Vector3 anchorPosition;
		public float timer = 3;
		public bool initialized = false;
		public int stage = 0;
		private float shootingCooldown = 0;

		void Start ()
		{
				
				anchorPosition = transform.position;
		}

		void Update ()
		{
				timer -= Time.deltaTime;
				if (timer <= 0 && !initialized) {
						Initialize ();
				}
		
				if (stage == 0) {
						MoveToAnchorPosition ();
						if (timer <= 0) {
								anchorPosition = ApplicationLogic.randomRotation () * Vector3.up * 15f;
								anchorPosition += transform.position;
								timer = 2;
								stage = 1;
						}
				}
				if (stage == 1) { 
						shootingCooldown -= Time.deltaTime;
						if (shootingCooldown <= 0) {
								gameObject.SendMessage ("dropPlasmid", anchorPosition);
								shootingCooldown = 0.2f;
						}
						if (timer <= 0) {
								timer = 3;
								stage = 0;
						}
				}
		}

		void Initialize ()
		{
				gameObject.GetComponent<EnemyAI> ().enabled = false;
				Camera.main.gameObject.GetComponent<BossCamera> ().enabled = true;
				Camera.main.gameObject.GetComponent<BossCamera> ().boss = gameObject;
				initialized = true;
		}

		void MoveToAnchorPosition ()
		{
				transform.position = Vector3.Lerp (transform.position, anchorPosition, 0.08f);
		}
}

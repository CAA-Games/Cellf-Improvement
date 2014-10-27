using UnityEngine;
using System.Collections;

public class BossCamera : MonoBehaviour
{

		public GameObject boss;
		public GameObject player;
		public float z = -20;
		public float bossiness = 0.5f;
		public float smoothness = 0.1f;

		void Update ()
		{
		
				if (boss && player) {
						Vector3 targetPosition = Vector3.Lerp (player.transform.position, boss.transform.position, bossiness);
						Vector3 newPosition = new Vector3 (targetPosition.x, targetPosition.y, z);
						gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, newPosition, smoothness);						
				} else {
						print ("DEAD");
						gameObject.GetComponent<WastedCamera> ().enabled = true;
						Destroy (this);
				}
		}

}

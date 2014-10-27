using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour
{
	
		void Update ()
		{
				if (Time.frameCount % 60 == 0) {
						if (gameObject.GetComponent<BacteriumLogic> ().cells.Count < 1) {
								AIDirector.PlayerDied ();
								gameObject.GetComponent<MoveToClickPersp> ().enabled = false;
				this.enabled = false;
				Destroy (gameObject);
						}
				}
		}
}

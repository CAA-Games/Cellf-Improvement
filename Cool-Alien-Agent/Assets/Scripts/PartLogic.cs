using UnityEngine;
using System.Collections;

public class PartLogic : MonoBehaviour {

	public GameObject player; // transform. parent
	public int forceMultiplier = -1;
	// Health as in how long (in seconds) does it take to destroy this cell with continuous calls to
	// TakeDamage() is once per update
	public float health = 2.0f;

	void Update () {
		rigidbody2D.AddForce(forceMultiplier * gameObject.transform.localPosition);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Plasmid") {
			PlasmidLogic logic = player.GetComponent<PlasmidLogic>();
			logic.addPlasmid(col.gameObject.GetComponent<PlasmidEffect>());
			Destroy (col.gameObject);
		}
	}

	public void TakeDamage() {
		health -= Time.deltaTime;
	}
}

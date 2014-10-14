using UnityEngine;
using System.Collections;

public class PartLogic : MonoBehaviour {

	public GameObject player; // transform. parent
	public int forceMultiplier = -1;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
}

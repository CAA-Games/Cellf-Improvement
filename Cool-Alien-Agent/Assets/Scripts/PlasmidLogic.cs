using UnityEngine;
using System.Collections;

public class PlasmidLogic : MonoBehaviour {

	public Color color = Color.green;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Bacterium"){
			col.gameObject.renderer.material.color = color;
			Destroy (gameObject);
		}
	}
}

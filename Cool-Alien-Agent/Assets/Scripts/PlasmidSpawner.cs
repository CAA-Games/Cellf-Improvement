using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlasmidSpawner : MonoBehaviour {

	public List<GameObject> partPrefabs;
	public GameObject instantiatingPlasmid;
	public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (1, 100) == 1) {
			spawnPlasmid();
		}
	}

	private void spawnPlasmid(){
		GameObject newPlasmid = (GameObject)Instantiate (instantiatingPlasmid, randomLocation(), Quaternion.identity);
		PlasmidEffect effect = newPlasmid.gameObject.AddComponent<PlasmidEffect>();
		randomizeAttributes (effect);
	}

	private Vector3 randomLocation(){
		return new Vector3 (Random.Range(-25f,25f),Random.Range(-25f,25f), 0);
	}

	private void randomizeAttributes(PlasmidEffect effect){
		effect.updateValues (Random.Range(-1f,2f), Random.Range(-1f,2f), Random.Range(-1f,2f), Random.Range(-1f,2f), Random.Range(-1f,2f), Random.Range(-1f,2f), partPrefabs[UnityEngine.Random.Range(0,partPrefabs.Count)]);
	}
}

using UnityEngine;
using System.Collections;

public class GoTowardsCenter : MonoBehaviour {

	public GameObject player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Physics2D.IgnoreCollision (this.collider2D, player.collider2D);
		rigidbody2D.AddForce (-1 * gameObject.transform.localPosition);
	}
}

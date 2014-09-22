using UnityEngine;
using System.Collections;

public class TestCubeScript : MonoBehaviour {

	private Vector3 lookVector;
	private Vector3 sizeVector;
	public float directionFactor;
	private float sizeFactor;
	public float speed = 10;

	// Use this for initialization
	void Start () {
		lookVector = new Vector3 (2, 2, 1);
		sizeVector = new Vector3 (2, 2, 2);
	}
	
	// Update is called once per frame
	void Update () {
		directionFactor = Mathf.Sin ((float)Time.frameCount / speed);
		sizeFactor = directionFactor + 1;
		sizeVector.Set (sizeFactor, sizeFactor, sizeFactor);
		lookVector.Set (0, 0, directionFactor);
		this.gameObject.transform.Rotate (lookVector);
		this.gameObject.transform.localScale = sizeVector;
	}
}
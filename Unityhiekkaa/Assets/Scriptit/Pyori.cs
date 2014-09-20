using UnityEngine;
using System.Collections;

public class Pyori : MonoBehaviour {
	public int vauhti = 2;

	void Update() {
		transform.Rotate(0, 0, vauhti + Time.deltaTime);
	}
}
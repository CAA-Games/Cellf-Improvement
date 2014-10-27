using UnityEngine;
using System.Collections;

public class WastedCamera : MonoBehaviour
{

		public float speed;
		public GameObject titleText;

		void Start ()
		{
				titleText.SetActive (true);
		}

		void Update ()
		{
				transform.Translate (Vector3.back * speed * Time.deltaTime);
		}
}

using UnityEngine;
using System.Collections;

public class PlasmidLogic : MonoBehaviour
{

		private ArrayList plasmidEffects;

		// Use this for initialization
		void Start ()
		{


				plasmidEffects = new ArrayList ();
				
		}
	
		// Update is called once per frame
		void Update ()
		{		
				if (plasmidEffects.Count > 0) {
						foreach (string effect in plasmidEffects) {
								print (effect);
						}
				
				}
		}

		void OnCollisionEnter2D (Collision2D col)
		{
				if (col.gameObject.tag == "Plasmid") {
						plasmidEffects.Add (col.gameObject.GetComponent<PlasmidEffect> ().getEffect ());
						Destroy (col.gameObject);
				}

		}
}

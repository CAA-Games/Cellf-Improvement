using UnityEngine;
using System.Collections;

public class PartLogic : MonoBehaviour
{

		public GameObject player; // transform. parent
		public int forceMultiplier = -1;
		// Health as in how long (in seconds) does it take to destroy this cell with continuous calls to
		// TakeDamage() is once per update
		public float maxHealth = 2.0f;
		public float currentHealth;

		void Start ()
		{
				currentHealth = maxHealth;
		}

		void Update ()
		{
				rigidbody2D.AddForce (forceMultiplier * gameObject.transform.localPosition);
		}

		void OnCollisionEnter2D (Collision2D col)
		{
				if (col.gameObject.tag == "Plasmid") {
						PlasmidLogic logic = player.GetComponent<PlasmidLogic> ();
						logic.addPlasmid (col.gameObject.GetComponent<PlasmidEffect> ());
						Destroy (col.gameObject);
				} else if (col.gameObject.tag != gameObject.tag) {
						print ("Ouch!");
						TakeDamage (1.0f);
				}
		}

		public void TakeDamage ()
		{
				currentHealth -= Time.deltaTime;
				gameObject.particleSystem.emissionRate = (10f - currentHealth / maxHealth * 10f);
		}

		public void TakeDamage (float amount)
		{
				print (gameObject + " just took " + amount + " damage!");
				currentHealth -= amount;
				gameObject.particleSystem.emissionRate = (10f - currentHealth / maxHealth * 10f);
		}
}

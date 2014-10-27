using UnityEngine;
using System.Collections;

public class CellLogic : MonoBehaviour
{
		public GameObject explosion;
		public GameObject player; // transform. parent
		public int forceMultiplier = -1;
		public bool infected = false;
		// Health as in how long (in seconds) does it take to destroy this cell with continuous calls to
		// TakeDamage() (once per update).
		public float maxHealth = 10.0f;
		public float currentHealth;
		private GameObject virus;
		// Amount of health damage cell takes per second
		public float virusResistance = 1.0f;
		// In percent (0-100)
		public float plasmidDropChance = 50.0f;

	#region Unity callbacks

		void Start ()
		{
				currentHealth = maxHealth;
				UpdateHealth ();
				gameObject.particleSystem.startColor = Color.white;
				if (infected) {
						ApplyVirusEffect ();
				}
		}

		void Update ()
		{
				rigidbody2D.AddForce (forceMultiplier * gameObject.transform.localPosition);
				if (infected) {
						ApplyVirusEffect ();
				}
		}

		void OnCollisionEnter2D (Collision2D col)
		{
				if (col.gameObject.tag == "Plasmid") {
						if (col.gameObject.GetComponent<PlasmidLogic> ().canBePickedUp) {
								AIDirector.xpUp (gameObject.tag);
								BacteriumLogic logic = player.GetComponent<BacteriumLogic> ();
								logic.addPlasmid (col.gameObject.GetComponent<PlasmidEffect> ());
								Destroy (col.gameObject);
						}
				} else if (col.gameObject.tag == "Virus") {
						InfectCellWithVirus (col.gameObject);
						AIDirector.xpUp (gameObject.tag, 10);
						AIDirector.infectionHappened ();
				} else if (col.gameObject.tag != gameObject.tag) {
						TakeDamage (1.0f);
						AIDirector.xpUp (gameObject.tag, 1);
				}
		}

	#endregion

	#region Virus

		void InfectCellWithVirus (GameObject virus)
		{
				infected = true;
				this.virus = virus;
				virus.SetActive (false);
				gameObject.particleSystem.startColor = Color.black;
				gameObject.particleSystem.startSize = 1.0f;
		}

		void SpreadVirus ()
		{
				int numberOfNewViruses = Random.Range (2, 5);
				for (int i = 0; i< numberOfNewViruses; i++) {
						GameObject newVirus = (GameObject)Instantiate (virus, transform.position, Quaternion.identity);
						newVirus.SetActive (true);
						Vector3 direction = randomShotTarget () - transform.position;
						if (direction.magnitude > 1) {
								direction = direction.normalized;
						}
			
						newVirus.rigidbody2D.AddForce (direction * 500);
				}
				Destroy (virus);
		}

		void ApplyVirusEffect ()
		{
				TakeDamage (virusResistance * Time.deltaTime);
		}

	#endregion

		public void TakeDamage (float amount)
		{
				currentHealth -= amount;
				UpdateHealth ();
		}

		private Vector3 randomShotTarget ()
		{
				return new Vector3 (transform.position.x + ApplicationLogic.minusOrPlus () * Random.Range (2f, 5.0f), transform.position.y + ApplicationLogic.minusOrPlus () * Random.Range (2f, 5.0f), 0);
		}

		private void UpdateHealth ()
		{
				if (currentHealth < 0) {
						if (infected) {
								SpreadVirus ();
						}
						if (Random.Range (0f, 100f) <= plasmidDropChance && !infected) {
								transform.parent.gameObject.SendMessage ("dropPlasmid", gameObject);
								
						} else {
								transform.parent.gameObject.SendMessage ("RemoveCell", gameObject);
								Destroy (Instantiate (explosion, transform.position, Quaternion.identity), 15.0f);
								Destroy (gameObject);	
						}
				}
				gameObject.particleSystem.emissionRate = (10f - currentHealth / maxHealth * 10f);
				
		}
}

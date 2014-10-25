using UnityEngine;
using System.Collections;

public class PartLogic : MonoBehaviour
{
		public GameObject explosion;
		public GameObject player; // transform. parent
		public int forceMultiplier = -1;
		public bool infected = false;
		// Health as in how long (in seconds) does it take to destroy this cell with continuous calls to
		// TakeDamage() (once per update).
		public float maxHealth = 10.0f;
		public float currentHealth;
		public GameObject virus;
		// Amount of health damage cell takes per second
		public float virusResistance = 1.0f;

	#region Unity callbacks

		void Start ()
		{
				currentHealth = maxHealth;
				UpdateHealth ();
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
						PlasmidLogic logic = player.GetComponent<PlasmidLogic> ();
						logic.addPlasmid (col.gameObject.GetComponent<PlasmidEffect> ());
						Destroy (col.gameObject);
				} else if (col.gameObject.tag == "Virus") {
						InfectCellWithVirus (col.gameObject);
				} else if (col.gameObject.tag != gameObject.tag) {
						TakeDamage (1.0f);
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
				return new Vector3 (transform.position.x + minusOrPlus () * Random.Range (2f, 5.0f), transform.position.y + minusOrPlus () * Random.Range (2f, 5.0f), 0);
		}

		private float minusOrPlus ()
		{
				if (Random.Range (0, 2) == 0) {
						return -1f;
				} else {
						return 1f;
				}
		}

		private void UpdateHealth ()
		{
				if (currentHealth < 0) {
						if (infected) {
								SpreadVirus ();
						}
						transform.parent.gameObject.SendMessage ("RemoveCell", gameObject);
						Destroy (Instantiate (explosion, transform.position, Quaternion.identity), 10.0f);
						Destroy (gameObject);		
				}
				gameObject.particleSystem.emissionRate = (10f - currentHealth / maxHealth * 10f);
		}
}

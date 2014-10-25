using UnityEngine;
using System.Collections;

public class PartLogic : MonoBehaviour
{
		public GameObject explosion;
		public GameObject player; // transform. parent
		public int forceMultiplier = -1;
		public bool infected = false;
		public int infection = 0;
		// Health as in how long (in seconds) does it take to destroy this cell with continuous calls to
		// TakeDamage() is once per update
		public float maxHealth = 2.0f;
		public float currentHealth;
		private GameObject virus;

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
				} else if(col.gameObject.tag == "Virus"){
						infected = true;
						virus = col.gameObject;
						InvokeRepeating("Infect", 2, 2F);
						col.gameObject.SetActive(false);
				} else if (col.gameObject.tag != gameObject.tag) {
						TakeDamage (1.0f);
				}
		}

		public void Infect(){
			infection++;
		gameObject.renderer.material.color = new Color (renderer.material.color.r -0.1f,renderer.material.color.g - 0.1f,renderer.material.color.b - 0.1f);
			if (infection == 5) {
				transform.parent.gameObject.SendMessage ("RemoveCell", gameObject);
				int viruses = Random.Range(2,5);
				for(int i = 0; i< viruses;i++){
					GameObject newVirus = (GameObject)Instantiate (virus, transform.position, Quaternion.identity);
					newVirus.SetActive(true);
					Vector3 direction = randomShotTarget() - transform.position;
					if (direction.magnitude > 1) {
						direction = direction.normalized;
					}
				
					newVirus.rigidbody2D.AddForce (direction * 500);
				}
				Destroy(virus);
			}
		}

		public void TakeDamage ()
		{
				currentHealth -= Time.deltaTime;
				UpdateHealth ();

		}

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
						transform.parent.gameObject.SendMessage ("RemoveCell", gameObject);
						Destroy (Instantiate (explosion, transform.position, Quaternion.identity), 10.0f);
						Destroy (gameObject);		
				}
				gameObject.particleSystem.emissionRate = (10f - currentHealth / maxHealth * 10f);
		}
}

using UnityEngine;
using System.Collections;

public class MusicFadeIn : MonoBehaviour
{

		public float startingVolume;
		public float targetVolume;
		public float fadeInTime;
		private float deltaVolume;

		// Use this for initialization
		void Start ()
		{
				audio.volume = startingVolume;
				deltaVolume = (targetVolume - startingVolume) / fadeInTime;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (audio.volume < targetVolume) {
						audio.volume += deltaVolume * Time.deltaTime;
				} else if (audio.volume > targetVolume) {
						audio.volume = targetVolume;
						this.enabled = false;
				}
		}
}

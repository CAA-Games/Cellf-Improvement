using UnityEngine;
using System.Collections;

public class SoundEffectPitchRandomizer : MonoBehaviour
{

		public float min;
		public float max;

		void Start ()
		{
				audio.pitch = Random.Range (min, max);
		}
}

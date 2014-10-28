using UnityEngine;
using System.Collections;

public class VirusLogic : MonoBehaviour
{

		void OnDestroy ()
		{
				AIDirector.virusDecayed ();
		}
}

using UnityEngine;
using System.Collections;

public class BlinkSprite : MonoBehaviour {

	public SpriteRenderer blinkingSprite;
	bool brighten;

	// Use this for initialization
	void Start () {
		brighten = true;
	}
	
	// Update is called once per frame
	void Update () {
		Color oldcolors = blinkingSprite.color;
		float transparency = blinkingSprite.color.a;
		float transpNew;
		if (brighten) { 
			transpNew = blinkingSprite.color.a + 0.01f;
		} else {
			transpNew = blinkingSprite.color.a - 0.01f;
		}

		if (transpNew >= 1f) {
			brighten = false;
		}

		if (transpNew <= 0f) {
			brighten = true;
		}


		blinkingSprite.color = new Color(oldcolors.r, oldcolors.g, oldcolors.b, transpNew);
	}
}

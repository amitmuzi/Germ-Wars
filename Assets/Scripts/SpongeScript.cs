using UnityEngine;
using System.Collections;

public class SpongeScript : MonoBehaviour
{
	public float maxDist;
	public Texture2D prefabTexture;
	void Update () 
	{
		foreach (Touch touch in Input.touches) {
			Vector3 touchPos = new Vector3 (Camera.main.ScreenToWorldPoint (touch.position).x, Camera.main.ScreenToWorldPoint (touch.position).y, 0);
			if (Vector3.Distance (transform.position, touchPos) <= maxDist) {
				transform.position=touchPos;
			}
		}
	}
}

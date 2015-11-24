using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

	GameObject[] players;
	public int dist2Paint;
	Texture2D texture;

	void Start () 
	{
		texture = GetComponent<SpriteRenderer> ().sprite.texture;
		players = GameObject.FindGameObjectsWithTag ("Player");
		Debug.Log (players[0]);

	}
	void Update () 
	{
		foreach(GameObject player in players)
		{
			Paint(player);
		}
	}
	void Paint(GameObject player)
	{
		Vector2 pixelUnderPlayer = (Vector2)Camera.main.WorldToScreenPoint (player.transform.position) * texture.height/Screen.height;
		print (pixelUnderPlayer);
		int xMin = (int)pixelUnderPlayer.x - dist2Paint;
		int xMax = (int)pixelUnderPlayer.x + dist2Paint;
		int yMin = (int)pixelUnderPlayer.y + dist2Paint;
		int yMax = (int)pixelUnderPlayer.y - dist2Paint;
		for (int y = yMin; y >= yMax; y--)
			for (int x = xMin; x <= xMax; x++)
			{
				Vector2 radius=new Vector2(x,y);
				if(Vector2.Distance(pixelUnderPlayer,radius)<=dist2Paint)
				{
					texture.SetPixel (x, y, player.GetComponent<SpongeScript>().prefabTexture.GetPixel (x, y));
				}
			}
		texture.Apply ();
	}

}

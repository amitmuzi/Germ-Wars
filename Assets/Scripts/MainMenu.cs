using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string numOfPlayersScene;

	public void PlayButton()
	{
		Application.LoadLevel (numOfPlayersScene);
	}
}

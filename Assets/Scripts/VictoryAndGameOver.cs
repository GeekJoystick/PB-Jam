using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryAndGameOver : MonoBehaviour
{

	public void OnTryAgainAndPlayAgain()
	{
		SceneManager.LoadScene(2);
	}


	public void OnMainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void OnQuit()
	{
		Application.Quit();
	}
}

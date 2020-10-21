using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
 
	public void OnPlay()
	{
		SceneManager.LoadScene(2);
	}

	public void OnEndless()
	{
		SceneManager.LoadScene(3);
	}

	public void OnCredits()
	{
		SceneManager.LoadScene(1);
	}

	public void OnExit()
	{
		Application.Quit();
	}

}

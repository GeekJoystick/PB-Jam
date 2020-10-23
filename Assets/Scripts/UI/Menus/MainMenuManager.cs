using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
	void Start(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
 
	public void OnPlay()
	{
		SceneManager.LoadScene(4);
	}

	public void OnEndless()
	{
		SceneManager.LoadScene(Random.Range(7, 10));
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

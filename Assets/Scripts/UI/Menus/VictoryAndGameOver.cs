using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryAndGameOver : MonoBehaviour
{

	void Start(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
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

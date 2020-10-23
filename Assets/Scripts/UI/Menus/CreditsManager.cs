using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CreditsManager : MonoBehaviour
{
	void Start(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void OnBack()
	{
		SceneManager.LoadScene(0);
	}

}

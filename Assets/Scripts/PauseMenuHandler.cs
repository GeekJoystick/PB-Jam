using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuHandler : MonoBehaviour
{
	public GameObject PauseMenu;
	public GameObject HealthBar;
	public GameObject Timer;
	public GameObject Score;
	public GameObject Ammo;
	public PlayerMovement StopShooting;


	void Start()
	{
		StopShooting = GameObject.Find("Player").GetComponent<PlayerMovement>();
		
	}


	void Update()
	{
		if (Input.GetKey(KeyCode.P))
		{
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0;
			Show();
			StopShooting.enabled = false;
		}	
	}

	public void OnResume()
	{
		Time.timeScale = 1;
		Hide();
		Cursor.lockState = CursorLockMode.Locked;
		StopShooting.enabled = true;
	}

	public void OnMainMenu()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1;
	}


	public void OnQuit()
	{
		Application.Quit();
	}

	public void Show()
	{
		PauseMenu.SetActive(true);
		HealthBar.SetActive(false);
		Timer.SetActive(false);
		Score.SetActive(false);
		Ammo.SetActive(false);
	}

	public void Hide()
	{
		PauseMenu.SetActive(false);
		HealthBar.SetActive(true);
		Timer.SetActive(true);
		Score.SetActive(true);
		Ammo.SetActive(true);
	}

}

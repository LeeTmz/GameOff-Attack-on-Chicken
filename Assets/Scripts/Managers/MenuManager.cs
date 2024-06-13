using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
	public bool isPaused;
	public GameObject pauseMenu;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			TogglePause();
		}
	}

	public void TogglePause()
	{
		isPaused = !isPaused;
		if (pauseMenu != null)
		{
			pauseMenu.SetActive(isPaused);
		}
		Time.timeScale = isPaused ? 0 : 1;
	}
	public bool IsPaused()
	{
		return isPaused;
	}

}

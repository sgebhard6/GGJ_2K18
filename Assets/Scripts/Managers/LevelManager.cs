using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void ReloadLevel()
	{
		SceneManager.LoadScene (GetCurrentScene ());
	}

	public void LoadNextLevel()
    {
		if (GetCurrentScene () + 1 == SceneManager.sceneCountInBuildSettings)
			SceneManager.LoadScene (0);
		else
			SceneManager.LoadScene (GetCurrentScene () + 1);
    }

	public void LoadMainMenu()
	{
		SceneManager.LoadScene (0);
	}

	int GetCurrentScene()
	{
		return SceneManager.GetActiveScene ().buildIndex;
	}
}

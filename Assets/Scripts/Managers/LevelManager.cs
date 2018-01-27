using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadNextLevel()
    {
		SceneManager.LoadScene (GetCurrentScene () + 1);
    }

	public void LoadMainMenu()
	{
		SceneManager.LoadScene (0);
	}

	int GetCurrentScene()
	{
		if (SceneManager.GetActiveScene ().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
			return -1;
		else
			return SceneManager.GetActiveScene ().buildIndex;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public GameObject creditsPanel;

	public void ToggleCreditsPanel()
	{
		creditsPanel.SetActive (!creditsPanel.activeSelf);
	}

    public void Quit()
    {
        Application.Quit();
    }
}

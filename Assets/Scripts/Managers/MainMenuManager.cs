using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

	public GameObject creditsPanel;
	public GameObject musicSourcePrefab;
	GameObject musicSource;

	void Start ()
	{
		musicSource = GameObject.Find ("MusicSource");
		if (musicSource == null) {
			musicSource = Instantiate (musicSourcePrefab);
			musicSource.name = "MusicSource";
		}
	}

	public void ToggleCreditsPanel ()
	{
		creditsPanel.SetActive (!creditsPanel.activeSelf);
	}

	public void Quit ()
	{
		Application.Quit ();
	}
}

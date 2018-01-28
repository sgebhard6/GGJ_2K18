using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

	public GameObject creditsPanel;
	public GameObject musicSourcePrefab;
	public GameObject scoreManagerPrefab;
	GameObject musicSource;
	GameObject scoreManager;

	void Start ()
	{
		musicSource = GameObject.Find ("MusicSource");
		if (musicSource == null) {
			musicSource = Instantiate (musicSourcePrefab);
			musicSource.name = "MusicSource";
		}

		scoreManager = GameObject.Find ("ScoreManager");
		if (scoreManager == null) {
			scoreManager = Instantiate (scoreManagerPrefab);
			scoreManager.name = "ScoreManager";
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
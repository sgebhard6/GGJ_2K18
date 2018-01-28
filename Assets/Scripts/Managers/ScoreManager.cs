using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	public TextMeshProUGUI scoreText;

	int score;

	void OnEnable ()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
		LightTransmitter.OnLevelCompleted += CalculateScore;
	}

	void OnDisable ()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
		LightTransmitter.OnLevelCompleted -= CalculateScore;
	}

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		GameObject gm = GameObject.Find ("GameManager");
		if (gm != null)
			scoreText = gm.GetComponent<GameManager> ().scoreText;
	}

	void CalculateScore (int _currentRayCount, int _currentLightCharges)
	{
		score += (_currentLightCharges * 100) - (_currentRayCount * 2);
		scoreText.text = "Score: " + score;
		PlayerPrefs.SetInt ("Score", score);
	}
}
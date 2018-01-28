using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowFinalScores : MonoBehaviour
{

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI highScoreText;
	int score;
	int highScore;

	void Start ()
	{
		score = PlayerPrefs.GetInt ("Score");
		highScore = PlayerPrefs.GetInt ("HighScore");

		scoreText.text = "Score: " + score;

		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt ("HighScore", highScore);
		}

		highScoreText.text = "High Score: " + highScore;
	}
}
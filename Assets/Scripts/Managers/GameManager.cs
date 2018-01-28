using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public GameObject levelCompletePanel;
	public GameObject levelFailPanel;
	public Sprite healthyPlant;
	public SpriteRenderer plant;
	public TextMeshProUGUI scoreText;

	public void PlantHit ()
	{
		plant.sprite = healthyPlant;
		foreach (Transform child in plant.transform)
			child.gameObject.SetActive (true);
		levelCompletePanel.SetActive (true);
	}

	public void FailLevel ()
	{
		levelFailPanel.SetActive (true);
	}
}
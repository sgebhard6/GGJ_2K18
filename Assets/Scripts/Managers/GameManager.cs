using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject levelCompletePanel;
	public GameObject levelFailPanel;

	public void PlantHit()
    {
		levelCompletePanel.SetActive(true);
    }

	public void FailLevel()
	{
		levelFailPanel.SetActive (true);
	}
}
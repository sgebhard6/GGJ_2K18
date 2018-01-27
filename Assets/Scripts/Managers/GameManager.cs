using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject levelCompleteCanvas;

	public void PlantHit()
    {
        levelCompleteCanvas.SetActive(true);
    }
}
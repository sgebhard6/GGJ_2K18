using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBorderWall : MonoBehaviour
{
	public enum Border
	{
		Top,
		Bottom,
		Left,
		Right
	}

	public Border border;

	Camera mainCam;

	void Start ()
	{
		mainCam = Camera.main;
	}

	void LateUpdate ()
	{
		SetBorder ();
	}

	void SetBorder ()
	{
		Vector3 newPos = new Vector3 ();
		switch (border) {
		case Border.Top:
			newPos = mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 0.5f, Screen.height, 0));
			break;
		case Border.Bottom:
			newPos = mainCam.ScreenToWorldPoint (new Vector3 (Screen.width * 0.5f, 0, 0));
			break;
		case Border.Left:
			newPos = mainCam.ScreenToWorldPoint (new Vector3 (0, Screen.height * 0.5f, 0));
			break;
		case Border.Right:
			newPos = mainCam.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height * 0.5f, 0));
			break;
		}

		transform.position = new Vector3 (newPos.x, newPos.y, 0);
	}
}

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

	void Start ()
	{
		Vector3 newPos = new Vector3 ();
		switch (border) {
		case Border.Top:
			newPos = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width * 0.5f, Screen.height, 0));
			break;
		case Border.Bottom:
			newPos = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width * 0.5f, 0, 0));
			break;
		case Border.Left:
			newPos = Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height * 0.5f, 0));
			break;
		case Border.Right:
			newPos = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height * 0.5f, 0));
			break;
		}

		transform.position = new Vector3 (newPos.x, newPos.y, 0);
	}
}

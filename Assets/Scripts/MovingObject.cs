using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
	public List<Transform> waypoints;
	public float speed = 5;
	public float threshold = 0.5f;

	Transform currentTarget;
	int currentIndex;
	float moveSpeed;

	void Start ()
	{
		currentTarget = waypoints [0];
		StartCoroutine (CheckDistance ());
	}

	void Update ()
	{
		MoveToPoint ();
	}

	void MoveToPoint ()
	{
		transform.position = Vector3.Lerp (transform.position, currentTarget.position, speed * Time.deltaTime);
	}

	IEnumerator CheckDistance ()
	{
		Vector2 currentPos = new Vector2 (transform.position.x, transform.position.y);
		Vector2 targetPos = new Vector2 (currentTarget.position.x, currentTarget.position.y);
		if (Vector2.Distance (currentPos, targetPos) < threshold) {
			ChangeIndex (1);
			currentTarget = waypoints [currentIndex];
		}

		yield return new WaitForSeconds (0.1f);

		StartCoroutine (CheckDistance ());
	}

	void ChangeIndex (int amount)
	{
		if (currentIndex + amount >= waypoints.Count)
			currentIndex = 0;
		else if (currentIndex + amount < 0)
			currentIndex = waypoints.Count - 1;
		else
			currentIndex += amount;
	}
}
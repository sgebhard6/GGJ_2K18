using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : PoweredObject
{
	public List<Transform> waypoints;
    
	public float threshold = 0.5f;

    float moveSpeed;
    int currentIndex;

    Transform currentTarget;	
    Coroutine distanceCheck;

    void Start ()
	{
		currentTarget = waypoints [0];

        if (activeAtStart)
            SetActive(true);
    }

	void FixedUpdate ()
	{
        if (activated)
        {
            ActiveState();
            if (distanceCheck == null)
                distanceCheck = StartCoroutine(CheckDistance());
        }
	}

    public override void ToggleActive()
    {
        if (distanceCheck != null)
        {
            StopCoroutine(distanceCheck);
            distanceCheck = null;
        }
        activated = !activated;
    }

    public override void SetActive(bool isActive)
    {
        if (distanceCheck != null)
        {
            StopCoroutine(distanceCheck);
            distanceCheck = null;
        }
        activated = isActive;
    }

    protected override void ActiveState ()
	{
        moveSpeed += speed * Time.deltaTime;
        transform.position = Vector3.Lerp (transform.position, currentTarget.position, moveSpeed);
	}

	IEnumerator CheckDistance ()
	{
		Vector2 currentPos = new Vector2 (transform.position.x, transform.position.y);
		Vector2 targetPos = new Vector2 (currentTarget.position.x, currentTarget.position.y);
		if (Vector2.Distance (currentPos, targetPos) < threshold) {
			ChangeIndex (1);
			currentTarget = waypoints [currentIndex];
            moveSpeed = 0;
		}

		yield return new WaitForSeconds (0.1f);

		distanceCheck = StartCoroutine (CheckDistance ());
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
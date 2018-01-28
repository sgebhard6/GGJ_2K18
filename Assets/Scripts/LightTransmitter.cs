using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightTransmitter : MonoBehaviour
{
	public delegate void LevelComplete (int _currentRayCount, int _currentLightCharges);

	public static event LevelComplete OnLevelCompleted;

	public bool devMode;
	public GameObject lightObject;
	public LineRenderer lightRayRendererPrefab;
	public Material newLineMat;
	public Material oldLineMat;
	public Image chargeIndicator;
	public List<Sprite> chargeLevels;
	public int maxRays = 5;
	public int maxLightCharges = 3;
	public float maxDistance = 150f;
	public float rotationSpeed = 50f;

	public LayerMask layerMask;

	GameManager gameManager;

	int currentRayCount = 0;
	int currentLightCharges = 0;
	//List<Ray> rayList = new List<Ray>();
	List<LightBeam> rayList = new List<LightBeam> ();
	LineRenderer oldLine;
	LineRenderer newLine;

	Vector3 newDir;

	Ray lightRay;

	bool disableControls = false;

	private void Start ()
	{
		gameManager = GetComponent<GameManager> ();
		currentLightCharges = maxLightCharges;
		Reset ();
	}

	private void Reset ()
	{
		lightRay = new Ray (lightObject.transform.position, lightObject.transform.right);
		currentRayCount = 0;
		rayList.Clear ();
	}

	void Update ()
	{
		if (disableControls)
			return;
		if (Input.GetKeyDown (KeyCode.Mouse0) || Input.GetKeyDown (KeyCode.Space)) {
			if (!devMode) {
				currentLightCharges--;
				if (currentLightCharges > -1)
					chargeIndicator.sprite = chargeLevels [currentLightCharges];
			}

			if (newLine != null) {
				oldLine = newLine;
				oldLine.material = oldLineMat;
			}

			newLine = Instantiate (lightRayRendererPrefab).GetComponent<LineRenderer> ();
			newLine.material = newLineMat;

			Reset ();
			TransmitLight (lightRay);
		}

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow))
			RotateLight (true);
		else if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow))
			RotateLight (false);
	}

	void LateUpdate ()
	{
		DrawRays ();
	}

	void TransmitLight (Ray _ray)
	{
		if (currentRayCount < maxRays) {
			currentRayCount++;
            
			RaycastHit2D hit = Physics2D.Raycast (_ray.origin, _ray.direction, maxDistance, layerMask);
			//rayList.Add(lightRay);
			rayList.Add (new LightBeam (lightRay, hit.distance));

			if (hit.collider != null) {
				if (hit.collider.tag.Equals ("Plant")) {
					gameManager.PlantHit ();
					disableControls = true;
					OnLevelCompleted (currentRayCount, currentLightCharges);
					return;
				}
				if (hit.collider.gameObject.layer == LayerMask.NameToLayer ("Reflective")) {
					newDir = Vector3.Reflect (_ray.direction, hit.normal);
					lightRay.origin = hit.point + hit.normal * 0.01f;
					lightRay.direction = newDir;
					TransmitLight (lightRay);
					return;
				}
			}

			if (currentLightCharges < 1) {
				gameManager.FailLevel ();
				disableControls = true;
				return;
			}
		}
	}

	public void RotateLight (bool direction)
	{
		if (direction == true) {
			//Rotate Up
			lightObject.transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);
		} else {
			//Rotate Down
			lightObject.transform.Rotate (Vector3.forward * -rotationSpeed * Time.deltaTime);
		}
	}

	void DrawRays ()
	{
		if (rayList.Count < 1)
			return;
		newLine.positionCount = rayList.Count + 1;
		Vector3[] points = new Vector3[rayList.Count + 1];
		for (int i = 0; i < points.Length; i++) {
			if (i < rayList.Count) {
				points [i] = rayList [i].beam.origin;
				//Debug.DrawRay(rayList[i].beam.origin, rayList[i].beam.direction * 20, Color.green);
			} else
				points [i] = rayList [i - 1].beam.origin + (rayList [i - 1].beam.direction * rayList [i - 1].distance);
            
		}

		newLine.SetPositions (points);
	}
}

public class LightBeam
{
	public Ray beam;
	public float distance;

	public LightBeam (Ray _beam, float _distance)
	{
		beam = _beam;
		distance = _distance;
	}
}
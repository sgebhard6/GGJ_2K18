using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTransmitter : MonoBehaviour {

    public GameObject lightObject;
    public LineRenderer lightRayRenderer;
    public int maxRays = 5;
    public float maxDistance = 150f;

    public LayerMask layerMask;

    int currentRayCount = 0;
    List<Ray> rayList = new List<Ray>();

    Vector3 newDir;

    Ray lightRay;

    private void Start()
    {
        lightRay = new Ray(lightObject.transform.position, lightObject.transform.right);
        lightRayRenderer.positionCount = maxRays;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TransmitLight(lightRay);
        }

        DrawRays();
	}

    void TransmitLight(Ray _ray)
    {
        if (currentRayCount < maxRays)
        {
            currentRayCount++;
            
            RaycastHit2D hit = Physics2D.Raycast(_ray.origin, _ray.direction, maxDistance, layerMask);
            rayList.Add(lightRay);

            if (hit.collider != null)
            {
                newDir = Vector3.Reflect(_ray.direction, hit.normal);
                lightRay.origin = hit.point + hit.normal * 0.01f;
                lightRay.direction = newDir;
                TransmitLight(lightRay);
            }
        }
    }

    void DrawRays()
    {
        if (rayList.Count < 1) return;
        Vector3[] points = new Vector3[maxRays];
        for(int i = 0; i < rayList.Count; i++)
        {
            points[i] = rayList[i].origin;
            //Debug.DrawRay(rayList[i].beam.origin, rayList[i].beam.direction * 100, Color.green, 1f);
        }

        lightRayRenderer.SetPositions(points);
    }
}
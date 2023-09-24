using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticCurve : MonoBehaviour
{
    public Transform startPoint;
    public Transform controlPoint;
    public Transform endPoint;
    public int numberOfPoints = 100;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numberOfPoints;
        DrawQuadraticCurve();
    }

    private void DrawQuadraticCurve()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            float t = i / (float)(numberOfPoints - 1);
            Vector3 point = CalculateQuadraticPoint(t);
            lineRenderer.SetPosition(i, point);
        }
    }

    private Vector3 CalculateQuadraticPoint(float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = (uu * startPoint.position) + (2 * u * t * controlPoint.position) + (tt * endPoint.position);

        return p;
    }
}
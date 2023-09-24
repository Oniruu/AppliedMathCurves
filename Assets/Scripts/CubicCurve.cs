using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicCurve : MonoBehaviour
{
    public Transform startPoint;
    public Transform controlPoint1;
    public Transform controlPoint2;
    public Transform endPoint;
    public int numberOfPoints = 100;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numberOfPoints;
        DrawCubicCurve();
    }

    private void DrawCubicCurve()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            float t = i / (float)(numberOfPoints - 1);
            Vector3 point = CalculateCubicPoint(t);
            lineRenderer.SetPosition(i, point);
        }
    }

    private Vector3 CalculateCubicPoint(float t)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = (uuu * startPoint.position) + (3 * uu * t * controlPoint1.position) + (3 * u * tt * controlPoint2.position) + (ttt * endPoint.position);

        return p;
    }
}
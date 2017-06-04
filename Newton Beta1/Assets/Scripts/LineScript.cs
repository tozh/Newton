using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;
    public float lengthOfLine;
    public float MAX_LENGTH = 6;

    List<Vector2> points;


    public void UpdateLine(Vector2 mousePos)
    {
        // first point of a line
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }

        float distance = Vector2.Distance(points.Last(), mousePos);
        if (distance > .1f)
        {
            Vector2 point = mousePos;
            // forbid the line longer than MAX_LENGTH
            if (distance + lengthOfLine > MAX_LENGTH)
            {
                Vector2 lastPoint = points[points.Count - 1];
                point = lastPoint + (mousePos - lastPoint) * ((MAX_LENGTH - lengthOfLine) / distance);
            }
            // draw other point
            if (lengthOfLine < MAX_LENGTH)
            {
                lengthOfLine += Vector2.Distance(points.Last(), mousePos);
                print(lengthOfLine);
                SetPoint(point);
            }
        }
    }
    // draw a single point
    void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
            edgeCol.points = points.ToArray();
    }

}

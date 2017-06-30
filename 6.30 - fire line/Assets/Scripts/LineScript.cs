using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{

	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCol;
	//public float lengthOfLine;
	//public float MAX_LENGTH = 6;

	public GameObject energyBar;
	//public float timeSpend = 0.0f;
	//public float recoverRate = 0.5f;
	//public float maxEnergy;
	//public float energyLeft;

	List<Vector2> points;
	/*
	void Update() {
		timeSpend += Time.deltaTime;
		if (timeSpend > 1) {
			energyLeft = Mathf.Min (maxEnergy, energyLeft + timeSpend*recoverRate);
			timeSpend = 0;
		}
	}
	*/


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
			if (energyBar.GetComponent<energyScript>().energyLeft - distance < 0)
			{
				Vector2 lastPoint = points[points.Count - 1];
				point = lastPoint + (mousePos - lastPoint) * (energyBar.GetComponent<energyScript>().energyLeft / distance);
			}
			// draw other point
			if (energyBar.GetComponent<energyScript>().energyLeft  > 0)
			{
				energyBar.GetComponent<energyScript>().energyLeft -= Vector2.Distance(points.Last(), point);
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

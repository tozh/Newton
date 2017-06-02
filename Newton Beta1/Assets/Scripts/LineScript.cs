using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour {

	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCol;
	public float MaxLen = 10000;
	public float lineLen = 0;
	List<Vector2> points;
	void Start() {
		lineRenderer = GetComponent<LineRenderer> ();
		edgeCol = GetComponent<EdgeCollider2D> ();
	}
	void Update() {
		lineRenderer.SetColors(Color.cyan,Color.cyan);
	}
	public void UpdateLine (Vector2 mousePos)
	{
		if (lineLen <= MaxLen) {
			if (points == null) {
				points = new List<Vector2>();
				SetPoint(mousePos);
				return;
			}

			float dist = Vector2.Distance (points.Last (), mousePos);
			if (dist > 0.001f) {
				SetPoint(mousePos);
				lineLen += dist;
			}
		}
	}

	void SetPoint (Vector2 point) {
		points.Add(point);
		lineRenderer.positionCount = points.Count;
		lineRenderer.SetPosition(points.Count - 1, point);
		if (points.Count > 1) {
			edgeCol.points = points.ToArray ();
		}
	}

}


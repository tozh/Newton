using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreatorScript : MonoBehaviour {

	public GameObject linePrefab;
	LineScript activeLine;
	public GameObject dragPrefab;
	DragScript activeDrag;

	public int MaxDraws = 3;//how many draws you can draw
	public int Draws = 0;
	public bool canDraw;

	public void setCanDraw(bool canDraw) {
		this.canDraw = canDraw;
	}

	void Start() {
		this.canDraw = true;
	}
	void Update ()
	{
		if (canDraw) {
			if (Input.GetMouseButtonDown(0))
			{	if (Draws < MaxDraws) {
					GameObject lineGO = Instantiate (linePrefab);
					activeLine = lineGO.GetComponent<LineScript>();
					GameObject dragGO = Instantiate (dragPrefab);
					activeDrag = dragGO.GetComponent<DragScript>();
				}
			}

			if (Input.GetMouseButtonUp(0))
			{	if (Draws < MaxDraws) {
					Draws++;
					Destroy(activeDrag.gameObject);
				}
				activeLine = null;

			}

			if (activeLine != null)
			{	
				Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				activeLine.UpdateLine (mousePos);
				activeDrag.UpdateDrag (mousePos);
			}
		}
	}
	public void destoryDrag() {
		if (activeDrag != null) {
			Destroy(activeDrag.gameObject);
		}
	}
}

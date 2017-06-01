using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour {

	public GameObject linePrefab;
	public bool canDraw = true;

	Line activeLine;

	public void setCanDraw (bool canDraw) {
		this.canDraw = canDraw;
	}

	void Update ()
	{
		if (canDraw) {
			if (Input.GetMouseButtonDown(0))
			{
				GameObject lineGO = Instantiate(linePrefab);
				activeLine = lineGO.GetComponent<Line>();
			}

			if (Input.GetMouseButtonUp(0))
			{
				activeLine = null;
			}

			if (activeLine != null)
			{
				Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				activeLine.UpdateLine(mousePos);
				print (mousePos);
			}	
		}


	}

}

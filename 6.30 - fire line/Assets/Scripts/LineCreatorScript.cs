#if UNITY_ANDROID && !UNITY_EDITOR
#define ANDROID
#endif


#if UNITY_IPHONE && !UNITY_EDITOR
#define IPHONE
#endif


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LineCreatorScript : MonoBehaviour {

	public GameObject ButtonPanel;

	public Button SettingButtonInButtonPanel;
	public Button StartButtonInButtonPanel;
	public Button ReplayButtonInButtonPanel;

	public ButtonDownScript SettingButtonDown;
	public ButtonDownScript StartButtonDown;
	public ButtonDownScript ReplayButtonDown;

	private bool isDown = false;
	public GameObject linePrefab;
	LineScript activeLine;
	public GameObject dragPrefab;
	DragScript activeDrag;

	public GameObject energyBar;
	//public int MaxDraws = 3;//how many draws you can draw
	//public int Draws = 0;
	public bool canDraw;

	public void setCanDraw(bool canDraw) {
		this.canDraw = canDraw;
	}

	void Start() {
		this.canDraw = true;
		SettingButtonDown = SettingButtonInButtonPanel.GetComponent<ButtonDownScript> ();
		StartButtonDown = StartButtonInButtonPanel.GetComponent<ButtonDownScript> ();
		ReplayButtonDown = ReplayButtonInButtonPanel.GetComponent<ButtonDownScript> ();
	}
	void Update ()
	{
		if (canDraw) {
			if (Input.GetMouseButtonDown(0))
			{
				if (!SettingButtonDown.ButtonIsDown () && !StartButtonDown.ButtonIsDown () && !ReplayButtonDown.ButtonIsDown () && ButtonPanel.gameObject.activeSelf) {
					if (energyBar.GetComponent<energyScript>().energyLeft > 0) 
					{	
						this.isDown = true;
						GameObject lineGO = Instantiate (linePrefab);
						Destroy (lineGO,5);
						activeLine = lineGO.GetComponent<LineScript>();
						GameObject dragGO = Instantiate (dragPrefab);
						activeDrag = dragGO.GetComponent<DragScript>();
					}
				}
			}

			if (Input.GetMouseButtonUp(0))
			{	
				if (this.isDown) {
					//Debug.Log (energyBar.GetComponent<energyScript> ().energyLeft);
					if (energyBar.GetComponent<energyScript>().energyLeft >= -0.1f) 
					{
						Destroy(activeDrag.gameObject);
					}
					activeLine = null;
					this.isDown = false;
				}
			}

			if (activeLine != null)
			{	
				Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				activeLine.UpdateLine (mousePos);
				activeDrag.UpdateDrag (mousePos);
			}
		}
	}
}

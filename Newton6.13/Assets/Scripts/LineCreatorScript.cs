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
	public Button QuitButtonInButtonPanel;
	public Button StartButtonInButtonPanel;
	public Button ReplayButtonInButtonPanel;

	public ButtonDownScript SettingButtonDown;
	public ButtonDownScript QuitButtonDown;
	public ButtonDownScript StartButtonDown;
	public ButtonDownScript ReplayButtonDown;

	private bool isDown = false;
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
		SettingButtonDown = SettingButtonInButtonPanel.GetComponent<ButtonDownScript> ();
		QuitButtonDown = QuitButtonInButtonPanel.GetComponent<ButtonDownScript> ();
		StartButtonDown = StartButtonInButtonPanel.GetComponent<ButtonDownScript> ();
		ReplayButtonDown = ReplayButtonInButtonPanel.GetComponent<ButtonDownScript> ();
	}
	void Update ()
	{
		if (canDraw) {
			if (Input.GetMouseButtonDown(0))
			{
				if (!SettingButtonDown.ButtonIsDown () && !QuitButtonDown.ButtonIsDown () && !StartButtonDown.ButtonIsDown () && !ReplayButtonDown.ButtonIsDown () && ButtonPanel.gameObject.activeSelf) {
					if (Draws < MaxDraws) 
					{	
						this.isDown = true;
						GameObject lineGO = Instantiate (linePrefab);
						activeLine = lineGO.GetComponent<LineScript>();
						GameObject dragGO = Instantiate (dragPrefab);
						activeDrag = dragGO.GetComponent<DragScript>();
					}
				}
			}

			if (Input.GetMouseButtonUp(0))
			{	
				if (this.isDown) {
					if (Draws < MaxDraws) 
					{
						Draws++;
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

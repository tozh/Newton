using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {
	GameObject ButtonPanel;
	void Start() {
		ButtonPanel = GameObject.Find ("Canvas1/ButtonPanel");
	}
	void Update() {
		if (ButtonPanel.activeSelf) {
			Time.timeScale = 1;
		} else {
			Time.timeScale = 0;
		}
	}
}

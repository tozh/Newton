using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	public Transform canvas;

	void Update() {
		
	}

	public void Menu() {
		canvas.gameObject.SetActive (true);
		Time.timeScale = 0;
	} 

	public void Resume() {
		canvas.gameObject.SetActive (false);
		Time.timeScale = 1;
	}
}

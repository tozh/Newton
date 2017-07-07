using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_In : MonoBehaviour {

    public Transform tutorial;
    public Transform setting;
	public 	LineCreatorScript line;
    // Use this for initialization

    public void onClick() {
		line.setCanDraw (false);
        tutorial.gameObject.SetActive(true);
        setting.gameObject.SetActive(false);
    }
	
}

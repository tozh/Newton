using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial_exit : MonoBehaviour {

    public Transform tutorial_panal;
	public Transform basic_panal;
    public LineCreatorScript line;

	// Use this for initialization
	public void onClick () {
        tutorial_panal.gameObject.SetActive(false);
        line.setCanDraw(true);
        //Debug.Log(line.canDraw);
        basic_panal.gameObject.SetActive (true);    }
	
}

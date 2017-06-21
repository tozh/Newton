using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour {

	public Transform tform;
	// Use this for initialization
	void Start () {
		tform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	public void UpdateDrag (Vector2 mousePos) {
		transform.position = mousePos;
	}
}

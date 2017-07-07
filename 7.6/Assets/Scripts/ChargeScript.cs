using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeScript : MonoBehaviour {

	public GameObject ball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vec = new Vector3 (ball.GetComponent<Transform> ().localPosition.x - 2, ball.GetComponent<Transform> ().localPosition.y, ball.GetComponent<Transform> ().localPosition.z);
		//gameObject.GetComponent<Transform>().localPosition = new Vector3(ball.transform.position.x+1.0f, ball.transform.position.y,ball.transform.position.z);
		gameObject.GetComponent<Transform>().localPosition = vec;
	}
}

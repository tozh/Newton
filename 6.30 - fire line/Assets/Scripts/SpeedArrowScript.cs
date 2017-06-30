using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedArrowScript : MonoBehaviour {
	public GameObject ball;
	private Ballscripts ballScript;
	private float Xlength = 34.86f;
//	private float Ylength = 11.75f;
	private Vector2 arrowScale = new Vector2 (0.1f, 0.1f); 
	private Vector2 ballMovement;
	// Use this for initialization
	void Start () {
		ballScript = ball.GetComponent<Ballscripts> ();
		ballMovement = new Vector2 (ballScript.speed.x * ballScript.direction.x, ballScript.speed.y * ballScript.direction.y);
//		float lengthOfMovement = Math.Sqrt (ballMovement.x * ballMovement.x + ballMovement.y * ballMovement.y);
//		Vector2 NormalizedMovement = new Vector2 (ballMovement.x / lengthOfMovement, ballMovement.y / lengthOfMovement);
//		float Angle = 180f * Math.Atan2 (ballMovement.x , ballMovement.y) / Math.PI;
		float Angle = (float)Math.Atan2 (ballMovement.y, ballMovement.x);
		//Debug.Log (Angle);
		float realXlength = Xlength * arrowScale.x;
//		float realYlength = Ylength * arrowScale.y;
		float XtoBall = (float)Math.Cos (Angle) * realXlength * 0.5f;
		float YtoBall = (float)Math.Sin (Angle) * realXlength * 0.5f;
		gameObject.GetComponent<Transform> ().localPosition = new Vector3 (ball.GetComponent<Transform> ().position.x + XtoBall, ball.GetComponent<Transform> ().position.y + YtoBall, ball.GetComponent<Transform> ().position.z + 1f);
		gameObject.GetComponent<Transform> ().localEulerAngles = new Vector3 (gameObject.GetComponent<Transform> ().localEulerAngles.x, gameObject.GetComponent<Transform> ().localEulerAngles.y, 180f * Angle / (float)Math.PI);
	}
}

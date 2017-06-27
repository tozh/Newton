using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;
using UnityEditor.Sprites;
using System;

public class CameraController : MonoBehaviour {

	public GameObject ball;
	public GameObject crow;
	private Vector3 start_ball;
	private Vector3 start_camera;
	private Vector3 offset = new Vector3(0,0,0);
	private Vector3 end_point;
	private float gameRangeWidth = 70.57f;
	private Transform ball_position;
	private Transform crow_position;

	void Start()
	{
		start_camera = transform.position;
		start_ball = ball.transform.position;
		ball_position = ball.transform;
		crow_position = crow.transform;
	}

	void LateUpdate()
	{
		if (Math.Abs (ball_position.position.y - crow_position.position.y) <= 2 && Math.Abs (ball_position.position.x - crow_position.position.x) <= 2) {
//			fail = true;
//			ball_position.position = crow_position.position;
//			Destroy (gameObject, 2);
//			ButtonPanel.gameObject.SetActive (false);//
//			Blackpanel2.gameObject.SetActive (true);//
		}
		else if (transform.position.x >= 0 && transform.position.x<=gameRangeWidth)
		{
			offset.x = ball.transform.position.x - start_ball.x;
			transform.position = start_camera + offset;
		}
	}
}
